namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=64
    ///
    /// analyse:
    /// 
    /// According Theorem 2.3 of Marius Beceanu the continued fraction expansion of
    /// √D, the remainders always take the form xn = (√(D)+bn)/cn
    /// where the numbers bn, cn, as well as the continued fraction digits an
    /// can be obtained by means of the following algorithm:
    /// 
    /// set a0 = √D, b1 = a0, c1 = D − a0*a0, and then compute
    /// an = (a0 + bn−1)/cn−1, bn = an−1 * cn−1 − bn−1, cn = (D − bn*bn)/cn-1
    /// 
    /// performance improvements:
    ///</summary>
    class Problem64 : Helper, IProblem
    {
        public double Execute()
        {
            int sum = 0;
            for (int n = 2; n <= 10000; n++) if (period_length(n).IsOdd()) sum++;
            return sum;
        }

        int period_length(int n)
        {
            int a0, b0, c0, a, b, c, result = 0;
            a0 = (int)Math.Sqrt(n);
            b = b0 = a0;
            c = c0 = n - a0 * a0;
            if (c == 0) return 0;
            do
            {
                a = (a0 + b) / c;
                b = a * c - b;
                c = (n - b * b) / c;
                result++;
            }
            while ((b != b0) || (c != c0));
            return result;
        }
    }
}
