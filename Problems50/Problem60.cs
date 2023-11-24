using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=60
    ///
    /// analyse:
    /// 
    /// performance improvements:
    ///</summary>
    class Problem60: Helper, IProblem
    {
        readonly HashSet<int> answer = new();
        const int max = 1051;
        int sum;

        public double Execute()
        {
            return Recurse(0);
        }

        private int Recurse(int prime)
        {
            while (sum == 0 && ++prime < max) if (OkPrime(prime))
            {
                answer.Add(prime);
                Recurse(prime + 1);
                answer.Remove(prime);
            }
            if (answer.Count == 5) sum = answer.Sum(x => primes[x]);
            return sum;
        }

        private bool OkPrime(int p)
        {
            foreach (var j in answer) if (!(IsPrime(Concat(p, j)) && IsPrime(Concat(j, p)))) return false;
            return true;
        }
        private static int Concat(int i, int j)
        {
            int p = primes[j];
            if (p <    10) return primes[i] * 10    + p;
            if (p <   100) return primes[i] * 100   + p;
            if (p <  1000) return primes[i] * 1000  + p;
            if (p < 10000) return primes[i] * 10000 + p;
            return 0;
            //return primes[i] * (int)Math.Pow(10,(int)(Math.Log10(primes[j])+1))+ primes[j];
            //return int.Parse(primes[i].ToString() + primes[j].ToString());
        }
        //private void Show(HashSet<int> fiveprimes)
        //{
        //    for (int p = 0; p < fiveprimes.Count; p++)
        //    {
        //        Console.Write("{0},",primes[fiveprimes.ElementAt(p)]);
        //    }
        //    Console.WriteLine(" sum = {0}", sum);
        //}
    }
}
