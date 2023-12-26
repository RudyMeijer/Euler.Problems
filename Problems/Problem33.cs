namespace Euler.Solutions
{
    /// <summary>
    /// The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, is obtained by cancelling the 9s.
    /// We shall consider fractions like, 30/50 = 3/5, to be trivial examples.
    /// There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.
    /// If the product of these four fractions is given in its lowest common terms, find the value of the denominator.
    ///</summary>
    /// <returns></returns>
    class Problem33 : IProblem
    {
        //
        // Alternate solution
        // original written in Python. Credits go to Mike from Dreamshire.
        //
        public double Execute()
        {
            var d = 1.0;
            for (int i = 1; i < 10; i++)
                for (int j = 1; j < i; j++)
                    for (int k = 1; k < j; k++)
                    {
                        var ki = k * 10f + i; // teller
                        var ij = i * 10f + j; // noemer
                        if (ij / ki == (double)j / k)
                            d *= ij / ki;
                    }
            return d;
        }
        //
        // My original solution: way to slow.
        //
        public double ExecuteOrg()
        {
            var result = 1.0;
            for (int num = 10; num < 99; num++)
                for (int den = num + 1; den < 100; den++)
                    for (int digit = 1; digit < 10; digit++)
                    {
                        if (num.Contains(digit) && den.Contains(digit))
                        {
                            var n = num.Remove(digit);
                            var d = den.Remove(digit);
                            if (d > 0 && (double)num / den == n / d)
                                result *= d / n;                                                                               //Console.WriteLine("digit={5} t={0} n={1} tt={2} nn={3} t/n={4}", t, n, tt, nn, (double) t / n,d);
                        }
                    }
            return result;
        }

    }
    static partial class Extensions
    {
        public static bool Contains(this int t, int d)
        {
            return (t % 10 == d || t >= d * 10 && t < d * 10 + 10);
        }
        public static double Remove(this int t, int d)
        {
            int tt = 0;
            if (t % 10 == d) tt = t / 10;
            if (t >= d * 10 && t < d * 10 + 10) tt = t % 10;
            return tt;
        }
    }
}
