using System.Diagnostics;
using System.Numerics;

namespace Euler.Solutions
{
    class Helper
    {
        static PrimeNumberSieve p = new();
        public static List<int> primes = p.ToList();
        public static bool IsPerfectKwadraat(int n)
        {
            int sqrt = (int)Math.Sqrt(n);
            return (sqrt * sqrt) == n;
        }
       /// <summary>
        /// Combination C(n/k) = n!/k!(n-k)!
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static double C(int n, int k)
        {
            return Fac(n) / Fac(k) / Fac(n - k);
        }
        private static double Fac(int n)
        {
            return n <= 1 ? 1 : n * Fac(n - 1);
        }

        /// <summary>
        /// Least Common Multiplier (KGV)
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static long kgv(params int[] numbers)
        {
            // 1) Remove all numbers from list which evenly divide other numbers in list.
            // 2) Check if multiple of highest number is divisible by rest of numbers in the list.
            List<int> num = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
                if (!numbers.Any(n => n > numbers[i] && n % numbers[i] == 0)) num.Add(numbers[i]);

            int highestNumber = num.Max();
            for (int lcm = highestNumber; ; lcm += highestNumber) if (num.All(i => lcm % i == 0)) return lcm;
        }
        public static long gcd(long a, long b)
        {
            if (b == 0) return a;
            if (a > b) return gcd(b, a % b); else return gcd(a, b % a);
        }
        // Deterministic Miller-Rabin for 32-bit and 64-bit integers
        public static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if ((n & 1) == 0) return false;

            if (n % 3 == 0) return n == 3;

            int d = n - 1;
            int s = 0;
            while ((d & 1) == 0) { d >>= 1; s++; }

            int[] witnesses = new int[] { 2, 7, 61 };
            foreach (var a in witnesses)
            {
                if (a % n == 0) return true;
                long x = ModPowLong(a, d, n);
                if (x == 1 || x == n - 1) continue;
                bool composite = true;
                for (int r = 1; r < s; r++)
                {
                    x = (x * x) % n;
                    if (x == n - 1) { composite = false; break; }
                }
                if (composite) return false;
            }
            return true;
        }

        public static bool IsPrime(long n)
        {
            if (n <= int.MaxValue) return IsPrime((int)n);
            if (n <= 1) return false;
            if (n % 2 == 0) return n == 2;
            if (n % 3 == 0) return n == 3;

            long d = n - 1;
            int s = 0;
            while ((d & 1) == 0) { d >>= 1; s++; }

            long[] witnesses = new long[] { 2, 325, 9375, 28178, 450775, 9780504, 1795265022 };
            var bigN = new System.Numerics.BigInteger(n);
            var bigD = new System.Numerics.BigInteger(d);
            foreach (var a in witnesses)
            {
                if (a % n == 0) return true;
                var bigA = new System.Numerics.BigInteger(a);
                var x = System.Numerics.BigInteger.ModPow(bigA, bigD, bigN);
                if (x == System.Numerics.BigInteger.One || x == bigN - System.Numerics.BigInteger.One) continue;
                bool composite = true;
                for (int r = 1; r < s; r++)
                {
                    x = (x * x) % bigN;
                    if (x == bigN - System.Numerics.BigInteger.One) { composite = false; break; }
                }
                if (composite) return false;
            }
            return true;
        }

        private static long ModPowLong(long value, long exponent, long modulus)
        {
            long result = 1;
            long baseVal = value % modulus;
            while (exponent > 0)
            {
                if ((exponent & 1) == 1) result = (result * baseVal) % modulus;
                baseVal = (baseVal * baseVal) % modulus;
                exponent >>= 1;
            }
            return result;
        }

        public static bool IsPalindrome(ulong n)
        {
            return (n == Reverse(n)); //19-5-2011
        }
        public static ulong Reverse(ulong n)
        {
            ulong r = 0;
            do r = r * 10 + n % 10;
            while ((n /= 10) > 0);
            return r;
        }
        public static string Factorsx(ulong nn)
        {
            if (nn < 2) { return "Neither Prime nor Composite"; }
            var response = nn + " = ";
            string message = "This Number is Prime";
            ulong p = 2;
            var n = nn;
            while (p * p <= n)
            {
                if (n % p == 0)
                {
                    response += p + " x ";
                    n /= p;
                }
                else p += p > 2 ? 2UL : 1UL;
            }
            return n == nn ? message : response + n;
        }
        public static IEnumerable<long> Permutation(long n)
        {
            int k = (int)Math.Log10(n) + 1;
            return Permutation(n, k);
        }
        public static IEnumerable<long> Permutation(long n, int k)
        {
            var p = (long)Math.Pow(10, (int)Math.Log10(n));
            var pow = (long)Math.Pow(10, k - 1);
            for (int i = 0; p > 0; i++)
            {
                var c = ((n / p) % 10) * pow;
                if (k == 1)
                    yield return c;
                else foreach (var perm in Permutation(n.RemoveDigit(i), k - 1))
                        yield return c + perm;

                p /= 10;
            }
        }
        // Test for primairly using the Miller-Rabin test.

        // Every prime yield to a^(p − 1) mod p = 1 where a is a coprime.

        // Miller-Rabin pseudoprime: a^(n − 1) mod n = 1
        // Euler pseudoprime.......: a^(n − 1)/2 mod n = +-1
        public static void UnitTest()
        {
            Debug.Assert(IsPerfectKwadraat(2) == false, "Error IsPerfectKwadraat 2");
            Debug.Assert(IsPerfectKwadraat(4) == true, "Error IsPerfectKwadraat 4");
            Debug.Assert(Factorsx(7653241) == "7653241 = 251 x 30491", "UnitTest factorsx failed.");
            Debug.Assert(C(4, 2) == 6, "UnitTest C(4,2) failed.");
            Debug.Assert(Fac(4) == 4 * 3 * 2 * 1, "UnitTest fac(4) failed.");
            Debug.Assert(kgv(2, 3, 5, 7, 11) == 2 * 3 * 5 * 7 * 11, "Unittest kgv failed.");
            //for (int i = 0; i < 10; i++) kgv(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20);
            Debug.Assert(kgv(1, 2, 3, 4, 5, 6, 7, 8, 9, 10) == 2520, "Unittest kgv failed.");
            //foreach (var item in Permutation(123456L, 2)) Console.WriteLine(item);
            Debug.Assert(Permutation(123L, 1).Count() == 3, "UnitTest Permutation1 failed.");
            Debug.Assert(Permutation(1234567L).Count() == Fac(7), "UnitTest Permutation2 failed.");
            Debug.Assert(gcd(42, 56) == 14, "UnitTest gcd failed.");
            Debug.Assert(IsPalindrome(12345678987654321) == true, "UnitTest Ispalindrome failed.");
            Debug.Assert(IsPalindrome(11) == true, "UnitTest Ispalindrome2 failed.");
            Debug.Assert(IsPalindrome(12) == false, "UnitTest Ispalindrome3 failed.");
            Stopwatch s = Stopwatch.StartNew();
            for (int i = 0; i < 2000; i++) Debug.Assert(IsPrime(i) == p.IsPrime(i), $"UnitTest Isprime({i}) failed.");
            Console.WriteLine($"Helper : {s.ElapsedMilliseconds} ms.");
        }
    }
}
