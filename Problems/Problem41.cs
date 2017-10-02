using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=41
    ///
    /// analyse:
    /// 
    /// The 8 and 9 digit pandigital 987654321 are divideble by 3 (Sum digits divide evenly by 3).
    /// and thus are composit numbers and no primes.
    /// So we start with a 7 digit padigital number 7654321.
    /// 
    /// performance improvements:
    /// 
    /// 1) Use permutation to generate pandigitals. This reduces loop from 6419754 to 5040. 
    /// 2) Use the fast Miller-Rabin test to check if a big number is a prime.
    /// 
    /// </summary>
    class Problem41: Helper,IProblem
    {
        public double Execute() 
        {
            foreach (var perm in Permutation(7654321L)) if ((perm.isPrime()))
                return perm;
            return 0;
        }
    }
}