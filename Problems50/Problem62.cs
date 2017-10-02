using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=62
    ///
    /// analyse:
    /// 
    /// performance improvements:
    ///</summary>
    class Problem62: Helper,IProblem
    {
        public double Execute()
        {
            Dictionary<string, int> list = new Dictionary<string, int>();
            long sum = 0, n = 10000;
            while (--n > 0)
            {
                string s = SortDigits(n * n * n);
                if (!list.ContainsKey(s)) list.Add(s, 0);
                if ( ++list[s] == 5 ) sum = n * n * n;
            }
            return sum;
        }

        private string SortDigits(long p)
        {
            var q = from c in p.ToString() orderby c select c;
            return new String(q.ToArray());
            //return q.Aggregate("", (seed, c) => seed + c);
        }
    }
}
