namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=45
    ///
    /// analyse:
    /// 
    /// 1) Every Hexagonal is also a Triangle.
    /// 2) Start looping with Hexagonal numbers because they increase faster than other two number types.
    /// 3) H143 gives 40755 so start with n = 144.
    /// 4) use difference: H(n) - H(n-1) = n(2n-1) - ((n-1)(2(n-1)-1)) = 4n-3
    /// 
    /// performance improvements: 
    /// 
    /// When we rewrite the pentagon formule P(n) = n(3n-1)/2 
    /// we get 1.5n*n - 0.5n - P(n) = 0 where P(n) = H(n)
    /// 
    /// </summary>
    class Problem45 : IProblem
    {
        public double ExecuteAltRoots() // 1 ms.
        {
            for (int n = 144; n < 10000000; n++)
            {
                // Find roots r = -B + Sqrt(B*B - 4AC)/2A
                var h = n * (2 * n - 1);
                var r = rootABCformule(1.5, -0.5, -h);
                if (r == (int)r)
                    return h;
            }
            return 0;
        }

        private double rootABCformule(double A, double B, double C)
        {
            var r = (-B + Math.Sqrt(B * B - 4 * A * C)) / (2 * A);
            return r;
        }
        public double Execute() // 1 ms.
        {
            int h = 40755;
            for (int n = 144; n < 20000000; n++) if (isPentagonal(h += 4 * n - 3)) return h;
            return 0;
        }

        private bool isPentagonal(long p)
        {
            return (Math.Sqrt(24 * p + 1) + 1) % 6 == 0;
        }
        private bool isPentagonal1(long p)
        {
            return (Math.Sqrt(8 * p + 1) + 1) % 4 == 0;
        }
    }
}