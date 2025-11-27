using System.Numerics;

namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=56
    ///
    /// analyse:
    /// 
    /// performance improvements:
    /// 
    /// 
    /// </summary>
    class Problem56 : Helper, IProblem
    {
        public double Execute()
        {
            var sum = 0;
            for (BigInteger x = 91; x < 100; x++) for (int y = 91; y < 100; y++)
                {
                    sum = Math.Max(sum, (x ^ y).ToString().Sum(c => c - '0'));
                }
            return sum;
        }
    }
}