using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// The Fibonacci sequence is defined by the recurrence relation:
    /// Fn = Fn1 + Fn2, where F1 = 1 and F2 = 1.
    /// Hence the first 12 terms will be:
    /// F1 = 1, F2 = 1, F3 = 2, F4 = 3... F11 = 89, F12 = 144
    /// 
    /// The 12th term, F12, is the first term to contain three digits.
    /// What is the first term in the Fibonacci sequence to contain 1000 digits?
    /// 
    /// solution:
    /// 
    /// The number of digits in F(n) is asymptotic to n*Log(Q) where Q = GoldenRatio = 1.61803;(see http://en.wikipedia.org/wiki/Fibonacci_number)
    /// </summary>
    /// <returns></returns>
    class Problem25: IProblem
    {
        double GoldenRatio = (1 + Math.Sqrt(5)) / 2; // ~ 1.6180339887
        public double Execute()
        {
            return (int)((1000 - GoldenRatio + 1) / Math.Log10(GoldenRatio));
        }
    }
}
