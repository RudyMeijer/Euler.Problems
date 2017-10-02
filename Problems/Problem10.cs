using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    /// Find the sum of all the primes below two million.
    ///</summary>
    /// <returns>142913828922</returns>
    class Problem10: IProblem
    {
        public double Execute()
        {
            var result = from p in new PrimeNumberSieve().TakeWhile(p => p < 2000000)
                         select (long)p;

            return result.Sum();
        }
    }
}
