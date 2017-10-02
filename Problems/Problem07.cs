using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// What is the 10001st prime number?
    ///</summary>
    /// <returns>104743</returns>
    class Problem07: Helper,IProblem
    {
        public double Execute()
        {
            var result = primes[10000];// PrimeNumberFast().ElementAt(10000);
            return result;
        }
    }
}
