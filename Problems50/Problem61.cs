namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=61
    ///
    /// analyse:
    /// 
    /// performance improvements:
    ///</summary>
    class Problem61 : Helper, IProblem
    {
        bool[] inuse = new bool[9] { true, true, true, false, false, false, false, false, false };
        int sum, begin;

        public double Execute()
        {
            cyclic(8, 0, 1);
            return sum;
        }

        private bool cyclic(int nr, int prev, int level)
        {
            int left, right, p, n = 19;
            if (isUsed(nr)) return false;

            while (true) if (Split(p = polygonal(nr, ++n), out left, out right))
                {
                    if (level == 1) begin = left;
                    if (level == 1 || prev == left)
                    {
                        if (level == 6 && begin == right)
                            sum += p;
                        for (int i = 3; i <= 8; i++) if (cyclic(i, right, level + 1))
                                sum += p;
                        if (sum > 0) return true;
                    }
                    else if (left > prev) break;
                }
            reset(nr);
            return false;
        }

        private int polygonal(int p, int n)
        {
            if (p == 3) return n * (n + 1) / 2;
            if (p == 4) return n * n;
            if (p == 5) return n * (3 * n - 1) / 2;
            if (p == 6) return n * (2 * n - 1);
            if (p == 7) return n * (5 * n - 3) / 2;
            if (p == 8) return n * (3 * n - 2);
            return -1;
        }

        private bool Split(int p, out int l, out int r)
        {
            l = p / 100;
            r = p % 100;
            return p > 1000 && p < 9999 && r >= 10;
        }
        private void reset(int nr)
        {
            inuse[nr] = false;
        }
        private bool isUsed(int nr)
        {
            if (inuse[nr]) return true;
            inuse[nr] = true;
            return false;
        }
    }
}
