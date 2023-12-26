namespace Euler.Solutions
{
    /// <summary>
    /// Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    /// If d(a) = b and d(b) = a, where a != b, then a and b are an amicable pair and each of a and b are called amicable numbers.
    /// For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
    /// Evaluate the sum of all the amicable numbers under 10000.
    /// 
    /// Solution: A cache (3 LOC's) can further improve speed by another 30%.
    ///</summary>
    /// <returns></returns>
    class Problem21 : IProblem
    {
        public double Execute() // 3,6 ms.
        {
            int sum = 0;
            for (int a = 2; a < 10000; a += 2)
            {
                int b = d(a);
                if (a > b && d(b) == a) sum += a + b;
            }
            return sum;
        }
        private int d(int n)
        {
            int sqr = (int)Math.Sqrt(n);
            int sum = (sqr == Math.Sqrt(n)) ? 1 - sqr : 1;
            for (int i = 2; i <= sqr; i++) if (n % i == 0) sum += i + n / i;
            return sum;
        }
        //
        // alternatieve
        //
        public double ExecuteBruteForce() // 489 ms.
        {
            int sum = 0;
            for (int a = 2; a < 10000; a++)
            {
                int b = dd(a);
                if (a != b && dd(b) == a)
                {
                    sum += a + b;
                }
            }
            return sum / 2;
        }
        private int dd(int n)
        {
            int sum = 1;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
