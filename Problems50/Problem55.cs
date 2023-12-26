namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=55
    ///
    /// analyse:
    /// 
    /// performance improvements:
    /// 
    /// 1) It turned out empirically that 24 loops yield also to the correct answer. 21 -> 15 ms.
    /// 2) Without Palindrome function execution is two times faster. 15 -> 7 ms. 
    /// 
    /// </summary>
    class Problem55 : Helper, IProblem
    {
        HashSet<ulong> cache = new HashSet<ulong>();

        public double Execute()
        {
            var sum = 0;
            for (ulong n = 0; n < 10000; n++) if (IsLychrel(n)) sum++;
            return sum;
        }

        private bool IsLychrel(ulong n)
        {
            ulong r = Reverse(n);
            for (int i = 0; i < 24; i++) if ((r = Reverse(n += r)) == n) return false;
            return true;
        }

        private new ulong Reverse(ulong n)
        {
            ulong r = 0;
            do r = r * 10 + n % 10; while ((n /= 10) > 0);
            return r;
        }

        private bool IsLychrel1(ulong n)
        {
            for (int i = 0; i < 24; i++) if (IsPalindrome(n += Reverse(n))) return false;
            return true;
        }
    }
}