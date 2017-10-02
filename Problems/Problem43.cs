using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=43
    ///
    /// analyse:
    /// 
    /// We can create a list with all 0-9 pan-digitals, see problem 41, then extract the 3 digit 
    /// subgroups and check for divisibility by apropiate prime. However this will yield to a hell 
    /// of a lot loops (about 10! fac). So we have to think of something smarter.
    /// 
    /// more analyse lead to the following axioma's:
    /// 
    /// axioma 1: a 10 digit pandigital can't start with a zero. d1 <> 0.
    /// axioma 2: d4 must be even. d4 = {0,2,4,6,8}
    /// axioma 3: d456 must be div by 5. d6 = {0,5}
    /// axioma 4: d678 must be div by 11. With d6=0 we get 011,022,033. This is div by 11 but contains dual digits.
    /// 
    /// So d6 must be a 5. 
    /// 
    /// Solution:
    /// 
    /// Create a array with digit d1 to d10.
    /// Increment each digit starting with digit one.
    /// Check for unique digit and apply dividible rules recursive.
    /// 
    /// performance improvements: 
    /// 
    /// </summary>
    class Problem43: IProblem
    {
        int[] d = new int[11];
        int[] divs = {0, 0, 0 ,0, 2, 3, 5, 7, 11, 13, 17 }; 
        List<long> pandigitals = new List<long>();

        public double Execute() // 8 ms.
        {
            CheckDigit(1);
            return pandigitals.Sum();
        }

        private void CheckDigit(int i)
        {
            int div = divs[i];
            for (d[i] = 0; d[i] < 10; d[i]++) if (Unique(i))
            {
                if (i >= 4)
                {
                    if ((d[i - 2] * 100 + d[i - 1] * 10 + d[i]) % div == 0)
                    {
                        if (i == 10) pandigitals.Add(d.Aggregate(0L, (c, x) => c * 10 + x));
                        else CheckDigit(i + 1);
                    }
                }
                else CheckDigit(i + 1);
            }
        }

        private bool Unique(int i)
        {
            if (i == 6 && d[i] != 5) return false; // 14 ms -> 8 ms.
            for (int j = 1; j < i; j++) if (d[j] == d[i]) return false;
            return true;
        }
    }
}