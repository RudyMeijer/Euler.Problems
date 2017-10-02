using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Euler.Solutions
{
    /// <summary>
    /// The following iterative sequence is defined for the set of positive integers:
    /// n  n/2 (n is even)
    /// n  3n + 1 (n is odd)
    /// Using the rule above and starting with 13, we generate the following sequence:
    /// 13  40  20  10  5  16  8;  4  2  1
    /// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
    /// 
    /// Which starting number, under one million, produces the longest chain?
    /// 
    /// performance improvements:
    /// 
    /// 1) i/2 -> i>>1                  // 3842 -> 2795 ms.
    /// 2) Inline (i & 1) == 0.         // 2795 -> 2344 ms.
    /// 3) Check only odd numbers.      // 2344 -> 1215 ms.
    /// 4) use cache to store terms.    // 1215 ->   82 ms.
    /// 
    ///</summary>
    /// <returns>837799</returns>
    class Problem14 : IProblem
    {
        int[] terms = new int[1000000];
        public double Execute()
        {
            terms[1] = 1;
            int tx = 0;
            int result = 0;
            for (int i = 1; i < 1000000; i+=2)
            {
                int t = Count(i);
                if (t > tx)
                {
                    tx = t;
                    result = i;
                }
            }
            return result;
        }
        private int Count(long i)
        {
            if (i >= 1000000)     return 1 + Count((i & 1) == 0 ? i >> 1 : (3 * i + 1));
            if (terms[i]==0)  terms[i] = 1 + Count((i & 1) == 0 ? i >> 1 : (3 * i + 1));
            return terms[i];
        }
        //
        // alternative
        //
        public double ExecuteBruteforce() // 2352 ms.
        {
            int max = 0;
            int result = 0;
            for (int s = 1; s < 1000000; s++)
            {
                int cnt = 0;
                long n = s;
                while (n != 1)
                {
                    n = ((n & 1) == 0) ? n = n / 2 : 3 * n + 1;
                    cnt++;
                }
                if (cnt > max)
                {
                    max = cnt;
                    result = s;
                }
            }
            return result;
        }

    }
}
