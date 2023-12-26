namespace Euler.Solutions
{
    /// <summary>
    /// Find the sum of all the even-valued terms in the Fibonacci sequence which do not exceed four million.1234567890123456789012345678901234567890
    /// </summary>
    /// <returns>4613732</returns>
    class Problem02 : IProblem
    {
        public double Execute()
        {
            var result = from v in new Fibonacci().TakeWhile(v => v < 4000000)
                         where v % 2 == 0 //&& v < 4000000
                         select v;

            return result.Sum();
        }
    }
}
