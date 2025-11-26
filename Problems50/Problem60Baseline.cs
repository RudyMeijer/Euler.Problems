namespace Euler.Solutions
{
    /// <summary>
    /// Baseline (unoptimized) implementation of Problem60 for benchmarking.
    /// Uses on-the-fly concatenation prime checks without precomputed compatibility.
    /// </summary>
    class Problem60Baseline : Helper, IProblem
    {
        readonly HashSet<int> answer = new();
        const int max = 1051;
        int sum;

        public double Execute()
        {
            sum = 0;
            Recurse(0);
            return -1;
        }

        private void Recurse(int prime)
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
        }

        private bool OkPrime(int p)
        {
            foreach (var j in answer)
            {
                int ij = Concat(j, p);
                if (!IsPrime(ij)) return false;
                int ji = Concat(p, j);
                if (!IsPrime(ji)) return false;
            }
            return true;
        }

        private static int Concat(int i, int j)
        {
            int q = primes[j];
            if (q < 10) return primes[i] * 10 + q;
            if (q < 100) return primes[i] * 100 + q;
            if (q < 1000) return primes[i] * 1000 + q;
            if (q < 10000) return primes[i] * 10000 + q;
            return 0;
        }
    }
}
