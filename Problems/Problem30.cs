namespace Euler.Solutions
{
    /// <summary>
    /// Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
    /// 1634 = 14 + 64 + 34 + 44
    /// 8208 = 84 + 24 + 04 + 84
    /// 9474 = 94 + 44 + 74 + 44
    /// The sum of these numbers is 1634 + 8208 + 9474 = 19316.
    /// Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
    /// 
    /// performance improvements:
    /// 
    /// 1) use a list to store Math.Pow()   // 788 -> 299 ms.
    /// 2) use n%10 ipv ToString()          // 299 -> 102 ms.
    /// 3) limit n to 200000                // 102 ->  20 ms.
    ///</summary>
    /// <returns></returns>
    class Problem30 : IProblem
    {
        List<int> pow = new List<int>();
        List<int> list = new List<int>();
        public double Execute()
        {
            for (int i = 0; i < 10; i++) pow.Add((int)Math.Pow(i, 5));
            for (int n = 2; n < 200000; n++) if (n == SumPow5(n)) list.Add(n);
            return list.Sum();
        }
        private int SumPow5(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                int d = n % 10;
                sum += pow[d];
                n /= 10;
            }
            return sum;
        }
        private int SumPow5Old(int n)
        {
            int sum = 0;
            string s = n.ToString();
            int l = s.Length;
            for (int i = 0; i < l; i++)
            {
                sum += pow[s[i] - '0'];
                //sum += (int)Math.Pow(s[i] - '0',5);
            }
            return sum;
        }
    }
}
