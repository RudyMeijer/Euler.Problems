namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=46
    ///
    /// analyse:
    /// 
    /// performance improvements: 
    /// 
    /// </summary>
    class Problem46 : IProblem
    {
        List<int> primes = new PrimeNumberSieve().ToList();
        public double Execute() // 15 - 9 ms.
        {
            for (int odd = 33; odd < 1000000; odd += 2)
            {
                if (!sum_of_a_prime_and_twice_a_square(odd)) return odd;
            }
            return 0;
        }

        private bool sum_of_a_prime_and_twice_a_square(int odd)
        {
            foreach (var prime in primes)
            {
                if (Math.Sqrt((odd - prime) / 2) % 1 == 0) return true;
                if (prime > odd) return false;
            }
            return false;
        }
    }
}