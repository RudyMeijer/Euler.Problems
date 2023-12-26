namespace Euler.Solutions
{
    /// <summary>
    /// Euler published the remarkable quadratic formula: n² + n + 41
    /// It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. However, when n = 40, 402 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly when n = 41, 41² + 41 + 41 is clearly divisible by 41.
    /// Using computers, the incredible formula  n² - 79n + 1601 was discovered, which produces 80 primes for the consecutive values n = 0 to 79. The product of the coefficients, -79 and 1601, is -126479.
    /// Considering quadratics of the form: n² + an + b, where |a| lt 1000 and |b| lt 1000
    /// 
    /// Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.
    /// </summary>
    /// <returns></returns>
    class Problem27 : IProblem
    {
        PrimeNumberSieve p = new PrimeNumberSieve();
        public double Execute()
        {
            var primes = from x in p.TakeWhile(x => x < 1000) select x;

            int nx = 0, ax = 0, bx = 0;
            foreach (var a in primes) foreach (var b in primes)
                {
                    int n = 0;
                    while (IsPrime(n * n - a * n + b)) n++;

                    if (n > nx) { nx = n; ax = -a; bx = b; }
                }
            return ax * bx;
        }
        private bool IsPrime(int n)
        {
            return (n > 0 && p.IsPrime(n));
        }
    }
}
