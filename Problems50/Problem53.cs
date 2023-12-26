namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=53
    ///
    /// analyse:
    /// 
    /// performance improvements:
    /// 
    /// 1) add break:             12374 us -> 880 us
    /// 2) let minimun n=23, r=4: 880 us -> 277 uS
    /// </summary>
    class Problem53 : Helper, IProblem
    {
        public double Execute()
        {
            long sum = 0;
            for (int n = 23; n <= 100; n++) for (int r = 4; r <= n; r++) if (C(n, r) > 1000000)
                    {
                        sum += (n - 2 * r + 1);
                        break;
                    }
            return sum;
        }
    }
}