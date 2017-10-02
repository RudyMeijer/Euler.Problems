using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
    /// 012   021   102   120   201   210
    /// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
    /// </summary>
    /// <returns></returns>
    class Problem24: IProblem
    {
        public double Execute()
        {
            string result = "", tokens = "0123456789";
            int million = 1000000-1;
            for (int i = 9; i >= 0; i--)
            {
                int f = (int)Fac(i);
                int n = million / f;
                result += tokens[n];
                tokens = tokens.Remove(n, 1);
                million -= n*f;
            }
            return double.Parse(result);
        }
        private double Fac(int n)
        {
            if (n <= 1) return 1;
            return n * Fac(n - 1);
        }
    }
}
