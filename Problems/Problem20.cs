using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// n! means n * (n - 1) * ... * 3 * 2 * 1
    /// Find the sum of the digits in the number 100!
    /// </summary>
    /// <returns></returns>
    class Problem20: IProblem
    {
        public double Execute() 
        {
            var result = from n in Fac(100).ToString() select n;
            return result.Sum(n => n - '0');
        }

        private BigInteger Fac(int n)
        {
            if (n == 1) return 1;
            return n * Fac(n - 1);
        }
    }
}
