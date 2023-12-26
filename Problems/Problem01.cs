namespace Euler.Solutions
{
    /// <summary>
    /// Add all the natural numbers below one thousand that are multiples of 3 or 5.
    /// </summary>
    /// <returns>233168</returns>
    class Problem01 : IProblem
    {
        public double Execute()
        {
            var result = from v in Enumerable.Range(0, 1000)
                         where v % 3 == 0 || v % 5 == 0
                         select v;

            return result.Sum();
        }
    }
}
