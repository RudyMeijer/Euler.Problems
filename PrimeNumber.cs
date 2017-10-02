using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// This class generates the PrimeNumber sequence: 2,3,5,7,11,13,17,19,...
    /// </summary>
    [Obsolete("use PrimeNumberSieve")]
    public class PrimeNumber: IEnumerable<int>
    {
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            yield return 2;
            for (int candidate = 3; candidate < 2000000; candidate += 2) if (IsPrime(candidate)) yield return candidate;
        }
        private bool IsPrime(int candidate)
        {
            var sqrt = Math.Sqrt(candidate);
            for (int i = 3; i <= sqrt; i += 2) if (candidate % i == 0) return false;
            return true;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
    /// <summary>
    /// Alternative 1: 
    /// Make use of axioma: A prime > 3 is of form 6k-1 6k+1 (2 times faster)
    /// </summary>
    public class PrimeNumberFast : IEnumerable<int>
    {
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            yield return 2;
            yield return 3;
            for (int candidate = 6; candidate < 2000000; candidate += 6)
            {
                if (IsPrime(candidate - 1)) yield return candidate - 1;
                if (IsPrime(candidate + 1)) yield return candidate + 1;
            }
        }
        private bool IsPrime(int candidate)
        {
            int f = -1;
            int r = (int)Math.Sqrt(candidate);
            while ((f += 6) <= r) if (candidate % f == 0 || candidate % (f + 2) == 0) return false;
            return true;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Alternative 2: 
    /// Use Sieve of Eratosthenes. 16 times faster.
    /// </summary>
    public class PrimeNumberSieve : IEnumerable<int>
    {
        uint[] bits;// 0 = noprime, 1 = prime.
        const int limit = 2000000;
        public PrimeNumberSieve()
        {
            int bit;
            bits = new uint[limit/32];
            for (int i = 0; i < bits.Length; i++) bits[i] = 0xaaaaaaaa; bits[0] = 0xaaaaaaac; //strike out all even bits. except 2.
            for (int i = 3; i < limit; i+=2) if (IsPrime(i)) // check all odd numbers. if isprime then
            {
                for (int j = 3; (bit=j*i) < limit; j+=2) reset(bit); //strike out the multiples of i.
            }
        }
        private void reset(int i)
        {
            bits[i / 32] &= ((1u << i % 32)^0xffffffff);
        }
        public bool IsPrime(int i)
        {
            return (bits[i / 32] & (1 << i % 32)) != 0;
        }
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            yield return 2;
            for (int i = 3; i < limit; i+=2) if (IsPrime(i)) yield return i;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        //
        // Test for primairly using the Miller-Rabin test.
        //
        // Every prime yield to a^(p − 1) mod p = 1 where a is a coprime.
        //
        // Miller-Rabin pseudoprime: a^(n − 1) mod n = 1
        // Euler pseudoprime.......: a^(n − 1)/2 mod n = +-1
        //
        public static void UnitTest()
        {
            Stopwatch s = Stopwatch.StartNew();
            //var result1 = from v in new PrimeNumber()     // 1413 ms.
            //var result1 = from v in new PrimeNumberFast() //  769 ms.
            var result1 = from v in new PrimeNumberSieve()  //   86 ms.
                          select v;
            int cnt = result1.Count(); //148933
            double sum = result1.Average(); //959584.70535072812
            Debug.Assert(sum == 959584.70535072812, "Unittest failed: PrimeNumber");
            //Console.WriteLine("PrimeNumber elap {0} ms",s.ElapsedMilliseconds);
            //
            // test IsPrime for big numbers.
            //
            //foreach (var prime in new PrimeNumberSieve())
            //{
            //    if (!IsPrime(prime))
            //        Debug.Assert(false, "Unittest failed: PrimeNumber Isprime("+prime+")");
            //}
        }
    }
}
