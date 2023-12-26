using System.Text;
//using System.Diagnostics;

namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=36
    /// 
    /// performance improvements:
    /// 1) Generate Palindromes to reduce loop from 1000000 to 1110 times.
    /// 
    /// </summary>
    class Problem36 : IProblem
    {
        public double Execute() // 3 ms.
        {
            int sum = 0;
            foreach (var i in new Palindrome())
                if (IsPalindrome(ConvertToBase(2, i)))
                    sum += i;
            return sum;
        }

        public double ExecuteBruteforce() // 2890 ms.
        {
            int sum = 0;
            for (int i = 1; i < 1000000; i++)
            {
                string bin = ConvertToBase(2, i);
                string dec = ConvertToBase(10, i);
                if (IsPalindrome(bin) && IsPalindrome(dec)) sum += i;
            }
            return sum;
        }
        private string ConvertToBase(int Base, int n)
        {
            const string d = "0123456789abcdefghijklmnopqrstuvwxyz";
            StringBuilder s = new StringBuilder();
            while (n > 0)
            {
                s.Insert(0, d[n % Base]);
                n /= Base;
            }
            return s.ToString();
        }
        private bool IsPalindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
                if (s[i] != s[s.Length - i - 1])
                    return false;
            return true;
        }
    }
}
