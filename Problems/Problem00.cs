using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// This class contains a reference loop.
    /// It takes 3,37 ms to execute on my machine (Intel Core Duo P8600 2.4 Ghz)
    /// 
    /// Use this class to compare relative execution times on your machine.
    /// 
    /// Problem03 takes 58 ms to execute on my machine.
    /// Suppose that on your machine Problem03 takes 80 ms and this class takes 6 ms to execute 
    /// then your solution of problem03 is more efficient. (6/3,37*58 ms > 80 ms )
    ///</summary>
    /// <returns></returns>
    class Problem00: IProblem
    {
        public double Execute() 
        {
            for (int i = 0; i < 1000000; i++)
            {
            } 
            return -1;
        }
    }
}
