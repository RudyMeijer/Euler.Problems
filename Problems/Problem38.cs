//using System.Diagnostics;

namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=38
    /// 
    /// Analyse:
    /// 
    /// Because the Euler website returns 918273645 as an incorrect answer we must find a greater pandigital number. 
    /// Axioma 1: The pandigital must start with digit 9!
    /// 
    /// Search for values of n and M which yield to a 9 digit pandigital.
    /// 
    ///         M       Pandigital      Result (S = to short, L = to long)
    ///         ======= =============== ======
    /// n=2     9       918             S
    ///         9x      9x1xx           S
    ///         9xx     9xx1xxx         S
    ///         9xxx    9xxx1xxxx       Okee (9 digits)
    /// n=3     9       91827           S
    ///         9x      9x1xx2xx        S
    ///         9xx     9xx1xxx2xxx3xxx L
    /// n=4     9       9182736         S
    ///         9x      9x1xx2xx3xx4xx  L
    /// n=5     9       918273645       Okee
    ///         9x      9x1xx2xx3xx4xx  L
    /// n=6     9       91827364554     L
    /// 
    /// So the only possibility is n = 2 and M is 9xxx.
    /// The definition of a pandigital says that all digits must be different so start with M = 9876 and count down to 9123.
    /// 
    /// performance improvements:
    /// 
    /// </summary>
    class Problem38 : IProblem
    {
        public double Execute() // 99 us
        {
            for (int M = 9876; M > 9123; M--) if (isPandigital(M * 100002))
                    return M * 100002; // M*1 + M*2

            return 0;
        }
        private bool isPandigital(int i)
        {
            bool[] digits = new bool[10];

            do digits[i % 10] = true; while ((i /= 10) > 0);
            for (int d = 1; d < 10; d++) if (!digits[d]) return false;

            return true;
        }
    }
}
