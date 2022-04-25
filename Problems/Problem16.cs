using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Euler.Solutions
{
    /// <summary>
    /// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
    /// 
    /// What is the sum of the digits of the number 2^1000?
    /// </summary>
    /// <returns></returns>
    class Problem16: IProblem
    {
        public double Execute() 
        {
            var result = from c in new BigInteger(1000).ToString()
                         select c-'0';
            return result.Sum();
        }
    }
}
