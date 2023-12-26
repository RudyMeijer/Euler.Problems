namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=50
    ///
    /// analyse:
    /// 
    /// 1) Sum all primes below limit of one million.
    /// 2) Substract primes from sum until a new prime is found.
    /// 
    /// performance improvements:
    /// 
    /// </summary>
    class Problem50 : Helper, IProblem
    {
        public double Execute()
        {
            int sum = 0;
            foreach (var prime in primes) if ((sum += prime) > 1000000)
                {
                    sum -= prime;
                    break;
                }
            foreach (var prime in primes) if (IsPrime(sum -= prime)) break;
            return sum;
        }
    }
}