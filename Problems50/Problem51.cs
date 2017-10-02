using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=51
    ///
    /// analyse:
    /// 
    /// 1) If we replace the last digit with 0-9 we get: xxxx0, xxxx1, xxxx2, ..., xxxx9. 
    /// This yield at least to four even numbers, xxxx2,xxxx4,xxxx6,xxxx8, which of cause aren't prime. 
    /// So the last digit can't be replaced.
    /// 
    /// 2) Digit must be less or equal than 2 to generate a family of eight.  0-7, 1-8, 2-9.
    /// 
    /// performance improvements: 30 ms -> 9 ms.
    /// 
    /// add 1) Don't check last digit for equalness.
    /// add 2) Only check digits less or equal 2.
    /// 
    /// </summary>
    class Problem51 : Helper, IProblem
    {
        public double Execute()
        {
            char digit = '0';
            foreach (var prime in primes) if (HasSameDigits(prime, ref digit) && digit <= '2') // add 2)
            {
                int cnt = 0;
                for (char i = '1'; i <= '9'; i++) if (IsPrime(Replace(prime, digit, i))) cnt++;
                if (cnt == 8) return prime;
            }
            return 0;
        }
        /// <summary>
        /// This function is true when a number has two or more same digits.
        /// </summary>
        private bool HasSameDigits(int number, ref char digit)
        {
            string s = number.ToString();
            if (s.Length == 6)
            for (int i = 0; i < s.Length - 1; i++) //add 1)
            {
                for (int j = i + 1; j < s.Length - 1; j++) if (s[i] == s[j])
                {
                    digit = s[i];
                    return true;
                }
            }
            return false;
        }

        private int Replace(int number, char oldChar, char newChar)
        {
            return int.Parse(number.ToString().Replace(oldChar, newChar));
        }
    }
}