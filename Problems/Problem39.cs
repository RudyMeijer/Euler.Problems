namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=39
    ///
    /// analyse:
    /// 
    /// 1) a² + b² = c²
    /// 2) a + b + c = p
    /// 1+2) yield  
    /// 3) b = (p²-2pa)/2(p-a)
    /// 4) c = p - a - b
    /// 
    /// b is only integral when (p²-2pa) is evenly divisible by 2(p-a)
    /// 
    /// performance improvements: 6 ms -> 0.2 ms
    /// 
    /// 1) Don't count doublures {3,4,5} and {4,3,5}. alpha 0 - 45 deg. Maximum a = p/(2+√2)
    /// 12 is the smallest perimeter which yield to an integral a, b & c {3,4,5}.
    /// So answer must be a multiple of 12.
    /// 
    /// </summary>
    class Problem39 : IProblem
    {
        public double Execute() //6 ms -> 0.2 ms
        {
            double sqr = 2 + Math.Sqrt(2);
            int max = 0, result = 0;

            for (int p = 12; p <= 1000; p += 12)
            {
                int sum = 0;
                for (int a = 1; a < p / sqr; a++)
                    if ((p * p - 2 * p * a) % (2 * (p - a)) == 0)
                        sum++;

                if (sum > max)
                {
                    max = sum;
                    result = p;
                }
            }
            return result;
        }
    }
}
//if (p == 840)
//{
//    var b = (p * p - 2 * p * a) / (2 * (p - a));
//    var c = p - a - b;
//    Console.WriteLine("p={0}, {{{1},{2},{3}}}", p, a, b, c);             // , Math.Sqrt(a * a + b * b) == c, a + b + c == p, Math.Sqrt(a * a + b * b));
//}
