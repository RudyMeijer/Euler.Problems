using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    static partial class Extensions
    {
        public static bool IsOdd(this int n)
        {
            return (n & 1) == 1;
        }
        public static bool Equal(this List<int> a, List<int> b)
        {
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }
        public static long RemoveDigit(this long nnn, int pos)
        {
            var p = (long)Math.Pow(10, (int)Math.Log10(nnn) - pos);
            return nnn / 10 / p * p + nnn % (p);
        }
        static int[] p = new PrimeNumberSieve().Take(54).ToArray();
		public static bool isPrime(this long n)
		{
			if (n == 2 || n == 3) return true;
			if (n == 1 || (n & 1) == 0) return false;
			double j = (n - 1) / 6.0;
			double k = (n + 1) / 6.0;
			if (j == (int)j || k == (int)k)// Possibleprime
			{
				var sqr = Math.Sqrt(n);
				for (int i = 0; i < p.Length && p[i] < sqr; i++)
				{
					{
						var r = n % p[i];
						if (r == 0) return false;
					}
				}
				//Console.WriteLine(PrimeNumberSieve.factorsx(n));
				return true;
			}
			return false;
		}
		public static bool isSquare(this long n)
		{
			var npos= Math.Abs(n);
			if (npos == 1 || npos == 2) return true;  
			var sqr = Math.Sqrt(npos);
			if (sqr == (int)sqr) return true;
			return false;
		}
		public static void UnitTest()
        {
            Stopwatch s = Stopwatch.StartNew();
            //foreach (var item in 1234567.Permutatie())
            {
            }
            //Console.WriteLine("Permutatie: {0} ms",s.ElapsedMilliseconds);
        }
        //[Obsolete("use .Sum() extension 16 -> 19 ms")]
        public static int SumDigits(this string s)
        {
            int sum = 0;
            for (int i = 0; i < s.Length; i++) sum += s[i] - '0';
            return sum;
        }

    }
}
