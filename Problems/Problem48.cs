namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=48
    ///
    /// analyse:
    /// 
    /// Because only the last ten digits are needed in the answer we can avoid big integers by 
    /// truncating each calculation to ten digits.
    /// 
    /// performance improvements:
    /// 
    /// </summary>
    class Problem48 : IProblem
    {
        public double Execute()
        {
            long sum = 0;
            long max = 10000000000L;
            for (int n = 1; n <= 1000; n++)
            {
                long quadrate = n;
                for (int loop = 1; loop < n; loop++, quadrate *= n) quadrate %= max;
                sum += quadrate;
            }
            return sum % max;
        }
    }
}