using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
    /// A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
    /// As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.
    /// 
    /// Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
    /// 
    /// performance improvements: 2065 ms -> 123 ms.
    /// 1) limit = 28123 -> 20161 see http://en.wikipedia.org/wiki/Abundant_number
    /// 2) for (j=0 -> for (j=i
    /// 3) if (number > limit) break;
    /// 4) sqr n/2 -> Math.Sqrt(n);
    /// 5) Sum+=i -> sum+=i+n/i;
    /// </summary>
    /// <returns></returns>
    class Problem23: IProblem
    {
        public double Execute()
        {
            //
            // Construct a list with abundant numbers.
            //
            const int limit = 20161; 
            List<int> abundants = new List<int>();
            for (int n = 12; n < limit; n++) if (d(n) > n) abundants.Add(n);
            //
            // Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
            //
            bool[] s = new bool[limit+1];
            int max = abundants.Count;
            for (int i = 0; i < max; i++) for (int j = i; j < max; j++) 
            {
                int number = abundants[i] + abundants[j];
                if (number > limit) break;
                s[number] = true;
            }
            var q = from nosum in s.Select((nosum, i) => (nosum) ? 0 : i) where nosum > 0 select nosum;
            int sum = q.Sum();
            return sum;
        }
        private int d(int n)
        {
            int sqr = (int)Math.Sqrt(n);
            int sum = (sqr == Math.Sqrt(n)) ? 1 - sqr : 1;
            for (int i = 2; i <= sqr; i++) if (n % i == 0) sum += i + n / i;
            return sum;
        }
    }
}
