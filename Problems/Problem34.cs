using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Euler.Solutions
{
    /// <summary>
    /// Find the sum of all numbers which are equal to the sum of the factorial of their digits.
    /// 
    /// solution:
    /// 
    /// Wikipedia,
    /// A factorion is a natural number that equals the sum of the factorials of its decimal digits. For example, 145 is a factorion because 1! + 4! + 5! = 1 + 24 + 120 = 145.
    /// There are just four factorions and they are 1, 2, 145 and 40585 (sequence A014080 in OEIS).
    /// 
    /// analyse:
    /// If n is a natural number of d digits that is a factorion, then 10d − 1 ≤ n ≤ 9!d. This fails to hold for d ≥ 8 thus n has at most 7 digits,
    /// and the first upper bound is 9,999,999. But the maximum sum of factorials of digits for a 7 digit number is 9!7 = 2,540,160 establishing
    /// the second upper bound.
    /// 
    /// performance improvements:
    /// 
    /// 1) According wiki the greatest 
    ///    factorion is 40585         // 1034 -> 15 ms.
    /// 2) Add Cache Fac 0 to 9       //   15 ->  3 ms.
    /// 
    /// </summary>
    class Problem34: IProblem
    {
        List<int> fac = new List<int>();
        public double Execute()
        {
            int sum=0;
            for (int i = 0; i < 10; i++) fac.Add(Fac(i));
            for (int n = 3; n < 41000; n++) if (n == FacDigits(n)) sum += n;
                    
            return sum;
        }
        private int FacDigits(int n)
        {
            int sum = 0;
            do sum += fac[n % 10]; while ((n /= 10) > 0);   
            return sum;
        }
        private int Fac(int n)
        {
            return (n <= 1) ? 1 : n * Fac(n - 1);
        }
    }
}
