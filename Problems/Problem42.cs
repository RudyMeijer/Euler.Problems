using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=42
    ///
    /// analyse:
    /// 
    /// performance improvements:
    /// 
    /// </summary>
    class Problem42: IProblem
    {
        public double Execute() 
        {
            var words = File.ReadAllText("text/words.txt").Replace("\"", "").Split(',');
            var values = from w in words select (from c in w select c - '@').Sum();
            var triang = from n in Enumerable.Range(1, 20) select n * (n + 1) / 2;
            var result = from v in values from t in triang where v == t select v;
            return result.Count();
        }
    }
}