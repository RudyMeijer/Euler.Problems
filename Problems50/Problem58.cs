using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=58
    ///
    /// analyse:
    /// 
    /// performance improvements:
    /// 
    /// 
    /// </summary>
    class Problem58 : Helper, IProblem
    {
        public double Execute()
        {
            int nominator = 0;
            int denominator = 1;
            for (int n = 1, len = 2; ; n += len, len += 2)
            {
                for (int i = 0; i < 3; i++) if (IsPrime(n += len)) nominator++;
                denominator += 4;
                if (10 * nominator < denominator) return len + 1;
            }
        }
    } 
}