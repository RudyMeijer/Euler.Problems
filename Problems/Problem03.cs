using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// What is the largest prime factor of the number 600851475143?
    /// </summary>
    /// <returns>6857</returns>
    class Problem03 : IProblem
    {
        public double Execute()
        {
            var result = from v in new PrimeNumberSieve().TakeWhile(v => v < Math.Sqrt(600851475143))
                         where 600851475143 % v == 0
                         select v;

            return result.Last();
        }
    }
}
