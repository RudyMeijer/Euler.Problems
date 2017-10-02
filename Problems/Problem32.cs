using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.
    /// The product 7254 is unusual, as the identity, 39  186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.
    /// Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
    /// HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
    /// 
    /// Solution:
    ///     i   x   j  =  p
    ///     1    9999  9999 
    ///    10     999  9990
    ///    99     100  9900
    ///   100      99  9900 -> duplicated
    ///   999      10  9990
    ///  9999       1  9999 
    /// 10000       1 10000 -> not pandigital
    /// 
    /// axioma 1: The product must be less than 10000 to get pandigital.
    /// axioma 2: To prohibit duplicates i must be less than j. According axioma 1 i must be less than sqrt(10000)=100
    /// axioma 3: String handling and Linq are slow.
    /// 
    /// Performance improvements:
    /// 
    /// ad 1) j < 10000/i    // 63409 -> 118 ms.
    /// ad 2) i < 100        //   118 ->  75 ms.
    /// ad 3) digits[i % 10] //    75 ->  11 ms.
    /// 
    ///</summary>
    /// <returns></returns>
    class Problem32: IProblem
    {
        public double Execute() 
        {
            HashSet<int> products = new HashSet<int>(); // Use HashSet to ignore duplicate products.
            for (int i = 1; i < 100; i++) for (int j = i; j < 10000 / i; j++)
            {
                if (isPandigital(i, j, i * j)) products.Add(i * j);
            }
            return products.Sum();
        }

        [Obsolete("to slow")]
        private bool isPandigitalOld(int i, int j, int p)
        {
            string s = i.ToString() + j.ToString() + p.ToString();
            if (s.Length != 9) return false;
            var q = from c in s
                    where c !='0'
                    select c;
            var r = q.Distinct();
            if (r.Count() != 9) return false;
            return true;
        }
        private bool isPandigital(int i, int j, int p)
        {
            bool[] digits = new bool[10];

            do digits[i % 10] = true; while ((i /= 10) > 0);
            do digits[j % 10] = true; while ((j /= 10) > 0);
            do digits[p % 10] = true; while ((p /= 10) > 0);

            for (int d = 1; d < 10; d++) if (!digits[d]) return false;
            
            return true;
        }
    }
}
