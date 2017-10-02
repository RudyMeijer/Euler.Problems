using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=52
    ///
    /// analyse:
    /// 
    /// Lets say we have a number n. According the problem description the number 6*n must have the same number of digits.
    /// this is only the case when the number n starts with digit 1. i.e. n = 1000 6n = 6000 (both four digits)
    /// n = 2000 6n = 12000. n and 6n have resp. 4 and 5 digits so they can never have the same digits.
    /// more precisely, n must be between 1000 and 1666 (=9999/6)
    /// 
    /// performance improvements:
    /// 
    /// Use bitmap to store digits. 50 -> 8 ms.
    /// 
    /// </summary>
    class Problem52 : Helper, IProblem
    {
        public double Execute()
        {
            for (int b = 1; b < 1000000; b *= 10) for (int n = b; n < 1.6 * b; n++)
            {
                var digits = Digits(1 * n);
                if (digits == Digits(2 * n) &&
                    digits == Digits(3 * n) &&
                    digits == Digits(4 * n) &&
                    digits == Digits(5 * n) &&
                    digits == Digits(6 * n))
                return n;
            }
            return 0;
        }
        private int Digits(int n)
        {
            int bitmap = 0;
            while (n >= 1)
            {
                bitmap |= 1 << (n % 10);
                n /= 10;
            };
            return bitmap;
        }
    }
}