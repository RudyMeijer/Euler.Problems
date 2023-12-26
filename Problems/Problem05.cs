namespace Euler.Solutions
{
    /// <summary>
    /// 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    /// What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// </summary>
    /// <returns>232792560</returns>
    class Problem05 : IProblem
    {
        public double Execute()
        {
            //return hlp.LCM(1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15,16,17,18,19,20);
            int j;
            for (int n = 380; ; n += 380)
            {
                for (j = 18; j > 10; j--) if (n % j != 0) break;
                if (j == 10) return n;
            }
        }
        public double ExecuteBruteForce()
        {
            int j;
            for (int n = 1; n < int.MaxValue; n++)
            {
                for (j = 1; j < 20; j++)
                {
                    if (n % j != 0) break;
                }
                if (j == 20) return n;
            }
            return 0;
        }
    }
}
