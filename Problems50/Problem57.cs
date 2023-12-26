namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=57
    ///
    /// analyse:
    /// 
    /// if you examine the function: Log10(Numerator)/Log10(Denominator) 
    /// you'll notice a pattern. It looks like that each 8th and 13th iteration 
    /// yield to a fraction 2 (iteration 8,13,21,26,34,39,...)
    /// So in 1000 iterations there are 2 positive interations every 13 iterations. 
    /// => answer: 2 * 1000 / 13 
    /// 
    /// performance improvements:
    /// 
    /// 
    /// </summary>
    class Problem57 : Helper, IProblem
    {
        public double Execute()
        {
            Fraction ff = iterations(14);
            Fraction f = iterations(39);
            return 2 * 1000 / 13;
        }
        private Fraction iterations(int i)
        {
            //
            // if i=0 return 1/2 else
            // return 1/(2+1/f) = f/(2*f+1)
            //
            if (i == 0) return new Fraction(1, 2);
            Fraction f = iterations(i - 1);
            return new Fraction(f.denominator, 2 * f.denominator + f.numerator);
        }
        private Fraction iterations1(int i)
        {
            //
            // if i=0 return 1/2 else
            // return 1/(2+1/f) = f/(2*f+1)
            //
            if (i == 0) return new Fraction(1, 2);
            Fraction f = iterations(i - 1);
            //Console.WriteLine("{0} {1}",i,f);
            return new Fraction(f.denominator, 2 * f.denominator + f.numerator);
        }

        struct Fraction
        {
            public long numerator;
            public long denominator;
            public bool moreDigits;
            public Fraction(long n, long d)
            {
                this.numerator = n;
                this.denominator = d;
                this.moreDigits = (int)Math.Log10(n + d) > (int)Math.Log10(d);
            }
            public override string ToString()
            {
                return String.Format("{0}/{1} {2} {3}", this.numerator + this.denominator, this.denominator, (double)this.numerator / this.denominator, moreDigits ? "Y" : " ");
            }
        }
    }
}