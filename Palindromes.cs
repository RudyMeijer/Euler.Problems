using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// This class generates a Palindrome sequence between 1 - 1000000.
    /// A palindrome has the form i, ii, aia, aiia, abiba, abiiba
    /// where i = 0-9, a = 1-9
    /// rem: all 1-digit odds are also binary palindromic! ( 5 => 101, 7 => 111, 9 => 1001 )
    /// </summary>
    public class Palindrome: List<int>
    {
        public Palindrome()
        {
            List<int> palin = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                palin.Add(i);      // one digit Palindrome. i
                palin.Add(11 * i); // two digit Palindrome. ii
                for (int a = 1; a < 10; a+=2)
                {
                    palin.Add( 101 * a +  10 * i); // tree digit Palindrome. aia
                    palin.Add(1001 * a + 110 * i); // four digit Palindrome. aiia
                    for (int b = 0; b < 10; b++)
                    {
                        palin.Add( 10001 * a +  1010 * b +  100 * i);// five digit Palindrome. abiba
                        palin.Add(100001 * a + 10010 * b + 1100 * i);// six digit Palindrome. abiiba
                    }
                }

            }
            this.AddRange(from p in palin where (p & 1) == 1 select p);
        }

        public static void UnitTest()
        {
            Stopwatch s = Stopwatch.StartNew();
            Palindrome pal=new Palindrome();
            //for (int i = 0; i < 1000; i++) pal = new Palindrome();
            //Console.WriteLine("Palindrome elap {0} ms",s.ElapsedMilliseconds);
            int cnt = pal.Count(); 
            double sum = pal.Average();
            Debug.Assert(cnt == 1110 && sum == 272795.31531531533, "Unittest failed: Palindrome.");
        }
    }
}
