using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
    /// a² + b² = c²
    /// For example, 3² + 4² = 9 + 16 = 25 = 5².
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    /// Find the product abc.
    ///</summary>
    /// <returns>31875000</returns>
    class Problem09: IProblem
    {
        public double Execute() // 470 us
        {
            for (int a = 1; ; a++) for (int b = a + 1, c = 1000 - a - b; b < c; b++, c--)
            {
                if (a * a + b * b == c * c) return a * b * c;
            }
        }
        
        public double ExecuteBruteForce() // 1147 ms
        {
            for (int a = 0; a < 1000; a++)
            {
                for (int b = 0; b < 1000; b++)
                {
                    for (int c = 0; c < 1000; c++)
                    {
                        if (a < b && b < c && a + b + c == 1000)
                        {
                            if (a * a + b * b == c * c)
                            {
                                return a * b * c;
                            }
                        }
                    }
                }
            }
            return 0;
        }
    }
}
