namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=60
    ///
    /// analyse:
    /// 
    /// performance improvements:
    ///</summary>
    class Problem60 : Helper, IProblem
    {
        // Replaced HashSet with List for ordered recursion and added compatibility cache
        readonly List<int> answer = new();
        const int max = 1051;
        int sum;

        // compatibility sets: compat[i] contains indices j such that concatenations of primes[i] and primes[j]
        // in both orders are prime
        HashSet<int>[] compat = null;
        int[] concatMultiplier = null;

        public double Execute()
        {
            BuildCompatibility();
            return Recurse(0);
        }

        private void BuildCompatibility()
        {
            compat = new HashSet<int>[max];
            concatMultiplier = new int[max];
            for (int i = 0; i < max; i++)
            {
                compat[i] = new HashSet<int>();
                int p = primes[i];
                if (p < 10) concatMultiplier[i] = 10;
                else if (p < 100) concatMultiplier[i] = 100;
                else if (p < 1000) concatMultiplier[i] = 1000;
                else if (p < 10000) concatMultiplier[i] = 10000;
                else concatMultiplier[i] = 100000;
            }

            // Precompute compatibility to avoid repeated expensive concatenation prime checks during recursion
            for (int i = 1; i < max; i++)
            {
                for (int j = i + 1; j < max; j++)
                {
                    int ij = primes[i] * concatMultiplier[j] + primes[j];
                    if (!IsPrime(ij)) continue;
                    int ji = primes[j] * concatMultiplier[i] + primes[i];
                    if (!IsPrime(ji)) continue;
                    compat[i].Add(j);
                    compat[j].Add(i);
                }
            }
        }

        public double Recurse(int prime)
        {
            while (sum == 0 && ++prime < max)
            {
                if (OkPrime(prime))
                {
                    answer.Add(prime);
                    Recurse(prime + 1);
                    answer.Remove(prime);
                }
            }
            if (answer.Count == 5) sum = answer.Sum(x => primes[x]);
            return sum;
        }

        private bool OkPrime(int p)
        {
            if (answer.Count == 0) return true;
            // fast membership checks using precomputed compatibility sets
            foreach (var j in answer) if (!compat[j].Contains(p)) return false;
            return true;
        }
        private static int Concat(int i, int j)
        {
            int p = primes[j];
            if (p < 10) return primes[i] * 10 + p;
            if (p < 100) return primes[i] * 100 + p;
            if (p < 1000) return primes[i] * 1000 + p;
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
