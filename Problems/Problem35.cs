using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=35
    /// 
    /// Performance improvement:
    /// 1) Remove all primes with digit 0,2,4,5,6,8 because they will not lead to a prime during permutation. //42243 -> 11 ms.
    /// 2) Don't use ToString() to rotate digits. Use n%10 instead.
    /// </summary>
    class Problem35: IProblem
    {
        List<int> primes = (from prime in new PrimeNumberSieve().TakeWhile(c => c < 1000000)
                            where !(from p in prime.ToString() select p).Any(c => ("024568".Contains(c)))
                            select prime).ToList();

        public double Execute()
        {
            int sum= 2; // prime 2 & 5 are removed form list but are circular.
            
            foreach (var prime in primes) if (IsCircular(prime)) sum++;

            return sum;
        }

        private bool IsCircular(int prime)
        {
            int length = (int)Math.Log10(prime);
            int circular = prime;
            for (int i = 0; i < length; i++)
            {
                circular = circular % 10 * (int)Math.Pow(10, length) + circular / 10;
                if (!primes.Contains(circular)) return false;
            }
            return true;
        }
        //
        // Alternative
        //
        private bool IsCircularOld(int prime)
        {
            string s = prime.ToString();
            int length = s.Length;
            for (int i = 0; i < length-1; i++)
            {
                s = s[length - 1] + s.Substring(0, length - 1);
                int circular = int.Parse(s);
                if (!primes.Contains(circular)) return false;
            }
            return true;
        }
    }
}
