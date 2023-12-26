//using System.Diagnostics;

namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=37
    /// 
    /// performance improvements:
    /// 1) Primes starting with 8 or 9 will not yield to a prime after stipping R to L.
    /// 2) Don't count primes 2,3,5,7  sum-17 is faster than primes.Skip(4) 
    /// 
    /// </summary>
    class Problem37 : IProblem
    {
        PrimeNumberSieve p = new PrimeNumberSieve();
        List<int> primes = new PrimeNumberSieve().TakeWhile(c => c < 800000).ToList();
        public double Execute() // 12 ms.
        {
            int sum = -17;
            foreach (var prime in primes)
                if (StripDigitsPrime(prime)) sum += prime;

            return sum;
        }

        private bool StripDigitsPrime(int prime)
        {
            int r = prime;
            int l = prime;
            int d = (int)Math.Pow(10, (int)Math.Log10(prime) + 1); // Divider 10, 100, 1000,...
            while (r >= 10)
            {
                r /= 10;      // Strip R digits.
                l %= d /= 10; // Strip L digits.
                if (!p.IsPrime(r) || !p.IsPrime(l)) return false;
            }
            return true;
        }
    }
}
