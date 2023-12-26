namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=49
    ///
    /// analyse:
    /// 
    /// start with next odd number 1489 and increment by two.
    /// 
    /// performance improvements:
    /// 
    /// </summary>
    class Problem49 : Helper, IProblem
    {
        public double Execute()
        {
            for (int i = 1489; ; i++) if (IsPrime(i) && IsPrime(i + 3330) && IsPrime(i + 6660))
                {
                    var perm = Permutation(i).Where(p => p == i + 3330);
                    if (perm.Count() > 0) return i * 100000000L + (i + 3330) * 10000L + i + 6660;
                }
        }
    }
}