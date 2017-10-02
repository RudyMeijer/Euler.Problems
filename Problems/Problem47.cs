using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=47
    ///
    /// analyse:
    /// 
    ///           
    /// 
    /// performance improvements:
    /// 
    /// Stop prime division when maximum prime number is reached yield to 20 x faster code execution.
    /// The maximum prime depends on primes already found.
    /// 
    /// number  = x * x * x * x  ( x = maximum prime number )
    /// number  = 2 * x * x * x  
    /// number  = 2 * 3 * x * x  
    /// number  = 2 * 3 * 5 * x  
    /// 
    /// 1) add square root4 test -> 2 times faster   if 57*57*57*57 > number then stop   int sqrt4 = (int)Math.Pow(number, 0.25); 
    /// </summary>
    class Problem47: IProblem
    {
        //PrimeNumberSieve primes = new PrimeNumberSieve();//14805 ms
        List<int> primes = new PrimeNumberSieve().ToList(); //2140 ms
        public double Execute() // 2140 -> 117 ms.
        {
            int i = 1; 
            for (int seq = 0; seq < 4; i++) if (PrimeDivisors(i) == 4) seq++; else seq = 0;
            return i - 4;
        }
        private int PrimeDivisors(int n)
        {
            int number = n;
            int count = 0;
            int maxPrime0 = (int)Math.Pow(number, 0.25);        // x * x * x * x
            int maxPrime1 = (int)Math.Pow(number / 2, 0.33);    // 2 * x * x * x
            int maxPrime2 = (int)Math.Pow(number / 6, 0.5);     // 2 * 3 * x * x

            foreach (var prime in primes)
            {
                if (count == 0 && prime >= maxPrime0) return 0; // 2 times faster.
                if (count == 1 && prime >= maxPrime1) return 0; // 2 times faster.
                if (count == 2 && prime >= maxPrime2) return 0; // 2 times faster.
                int exp = 0;
                while (number % prime == 0)
                {
                    number /= prime;
                    exp = 1;
                }
                count += exp;
                if (number == 1) return count;
            }
            return count;
        }
    }
}