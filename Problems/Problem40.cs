namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=40
    ///
    /// analyse:
    /// 
    /// A picture tells more than a thousand words.
    /// 
    /// int b =       1          2              3                4
    /// int c =   <-9x1=9-><--90x2=180--><--900x3=2700--><--9000x4=36000--><--enz-->
    ///         0.12345678910......97..99100..........9991000..........999910000
    /// int o =   1        10      ^^    190             2890          ^^^^38890
    /// int f = (x / b + p) = ---> 97
    /// int e = (x % b) = -------------------------------------------> 0123
    /// int p =   1        10            100             1000              10000
    ///                    
    /// performance improvements: 
    /// 
    /// </summary>
    class Problem40 : IProblem
    {
        public double Execute() // 1 us
        {
            return d(1) * d(10) * d(100) * d(1000) * d(10000) * d(100000) * d(1000000);
        }

        public int d(int n)
        {
            int o = 1;                          // Base offset: 1, 10, 190, 2890, 38890
            int p = 1;                          // Power of 10: 1, 10, 100, 1000, 10000
            for (int b = 1; b <= 6; b++)        // Base: 1 - 6
            {
                int c = 9 * p * b;              // Chars in a base: 9, 180, 2700, 36000
                int x = n - o;                  // Offset in  base: 0 - c 
                if (x < c) return (x / b + p) / (int)Math.Pow(10, b - 1 - x % b) % 10;
                o += c; p *= 10;
            }
            return 0;
        }
        public int dd(int n)
        {
            int o = 1;                          // Base offset: 1, 10, 190, 2890, 38890
            int p = 1;                          // Power of 10: 1, 10, 100, 1000, 10000
            for (int b = 1; b <= 6; b++)        // Base: 1 - 6
            {
                int c = 9 * p * b;              // Chars in base: 9, 180, 2700, 36000
                if (n < o + c)
                {
                    int f = (n - o) / b + p;    // Whole number where n is pointing to i.e.: 97
                    int e = (n - o) % b;        // Digit in number where n is pointing to: 0,1,2,3
                    int result = f / (int)Math.Pow(10, b - 1 - e) % 10;
                    return result;
                }
                o += c; p *= 10;
            }
            return 0;
        }
    }
}