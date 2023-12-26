namespace Euler.Solutions
{
    /// <summary>
    /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit
    /// numbers is 9009 = 91 x 99. Find the largest palindrome made from the product of two 3-digit numbers.
    /// </summary>
    /// <returns>906609</returns>
    class Problem04 : IProblem
    {
        public double Execute()
        {
            int result = 0;
            for (int i = 999; i >= 100; i--) for (int j = i; j >= 100; j--)
                {
                    int prod = i * j;
                    if (prod < result) break;
                    if (IsPalindrome(prod))
                        result = prod;
                }
            return result;
        }
        private bool IsPalindrome(int prod)
        {
            string s = prod.ToString();
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - i - 1]) return false;
            }
            return true;
        }
    }
}
