namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=44
    ///
    /// analyse:
    /// 
    /// performance improvements: 
    /// not proud on this one.
    /// </summary>
    class Problem44 : IProblem
    {
        public double Execute1() // 492 ms.
        {
            var Pentagonals = new List<int>();
            for (int n = 1; n < 4000; n++) Pentagonals.Add(n * (3 * n - 1) / 2);

            foreach (var i in Pentagonals) foreach (var j in Pentagonals)
                {
                    if (isPentagonal(i + j) && isPentagonal(i - j))
                        return i - j;
                }
            return 0;
        }
        public double Execute() // 2 ms.
        {
            var Pentagonals = new List<int>();
            for (int n = 1000; n < 2200; n++) Pentagonals.Add(n * (3 * n - 1) / 2);

            foreach (var j in Pentagonals) foreach (var i in Pentagonals)
                    if (isPentagonal(i + j) && isPentagonal(i - j))
                        return i - j;
            return 0;
        }

        private bool isPentagonal(long p)
        {
            return (Math.Sqrt(24 * p + 1) + 1) % 6 == 0;
        }

        private long Pentagonal(int n)
        {
            return n * (3L * n - 1) / 2;
        }
    }
}