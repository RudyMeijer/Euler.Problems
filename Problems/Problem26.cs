namespace Euler.Solutions
{
    /// <summary>
    /// A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given
    /// 1/2 =  0.5 
    /// 1/3 =  0.(3) 
    /// 1/4 =  0.25 
    /// 1/5 =  0.2 
    /// 1/6 =  0.1(6) 
    /// 1/7 =  0.(142857) 
    /// 1/8 =  0.125 
    /// 1/9 =  0.(1) 
    /// 1/10 =  0.1 
    /// Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.
    /// 
    /// Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
    /// 
    /// Solution: Find length of cyclic numbers. http://en.wikipedia.org/wiki/Cyclic_number
    /// </summary>
    /// <returns></returns>
    class Problem26 : IProblem
    {
        int[] primes = new PrimeNumberSieve().TakeWhile(p => p < 1000).SkipWhile(p => p < 10).ToArray();

        public double Execute() // 1 ms.
        {
            int l = 0;
            int d = 0;
            foreach (var prime in primes)
            {
                int len = CyclicNumberLength(prime);
                if (len > l)
                {
                    l = len;
                    d = prime;
                }
            }
            return d;
        }
        private int CyclicNumberLength(int p) // 1 ms.
        {
            int r = 1;
            int l = 0;
            do
            {
                int x = r * 10;
                int d = (int)x / p;
                r = x % p;
                l++;
            }
            while (r != 1);
            return l;
        }
        private string CyclicNumberOld(int p) // 65 ms.
        {
            int r = 1;
            string n = "";
            do
            {
                int x = r * 10;
                int d = (int)x / p;
                r = x % p;
                n += d;
            }
            while (r != 1);
            return n;
        }
        public double Execute1() // 3 ms. credits go to Grant Kot. 
        {
            //DateTime start = DateTime.Now;
            int numLongestRecurring = 1;
            int cycle = 0;
            for (int i = 1; i < 1000; i++)
            {
                int power = 1, lam = 1;
                int tortoise = 1 / i;
                int tortoiseRem = (1 % i) * 10;
                int hare = tortoiseRem / i;
                int hareRem = (tortoiseRem % i) * 10;
                while (tortoise != hare || tortoiseRem != hareRem)
                {
                    if (power == lam)
                    {
                        tortoise = hare;
                        tortoiseRem = hareRem;
                        power *= 2;
                        lam = 0;
                    }
                    hare = hareRem / i;
                    hareRem = (hareRem % i) * 10;
                    lam++;
                }
                if (lam > cycle)
                {
                    cycle = lam;
                    numLongestRecurring = i;
                }
            }
            //Console.WriteLine("Number with longest recurring cycle: {0}\nCycle Length: {1}", numLongestRecurring, cycle);
            //Console.WriteLine((DateTime.Now - start).TotalMilliseconds + " ms");
            //Console.ReadLine();
            return numLongestRecurring;
        }
    }
}
