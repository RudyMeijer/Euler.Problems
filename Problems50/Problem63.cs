using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=63
    ///
    /// analyse:
    /// 
    /// x^n has n digits when: 10^(n-1) <= x^n < 10^n ==> so x must be less than 10.
    /// Substitute x = 9       10^(n-1) <= 9^n < 10^n ==> so n must be less than 22.
    /// 
    /// performance improvements:
    ///</summary>
    class Problem63: Helper,IProblem
    {
        public double Execute()
        {
            int sum = 0;
            for (int n = 1; n < 22; n++) for (int x = 1; x < 10; x++)
            {
                if ((int)Math.Log10(Math.Pow(x, n)) + 1 == n) ++sum;
            }
            return sum;
        }
    }
}
                //Console.WriteLine("{0} {1} {2}",x,n,Math.Pow(x, n));
