using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:
    /// 1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
    /// It is possible to make £2 in the following way:
    /// 1£1 + 150p + 220p + 15p + 12p + 31p
    /// How many different ways can £2 be made using any number of coins?
    /// 
    /// performance improvements:
    /// 
    /// 1) Eliminate coin order (int i = 0 -> i = j)         // ∞∞ -> 59 ms.
    /// 2) Stop substracting 1 pence (i<coins.Length -> i<7) // 59 ->  1 ms.
    /// 
    /// </summary>
    /// <returns></returns>
    class Problem31: IProblem
    {
        int[] coins = { 200, 100, 50, 20, 10, 5, 2, 1};
        int cnt;
        public double Execute() 
        {
            return SubstractCoin(0,200);
        }

        private int SubstractCoin(int j, int sum)
        {
            for (int i = j; i < 7 ; i++) if (sum - coins[i] >= 0)
            {
                SubstractCoin(i, sum-coins[i]);
            }
            return ++cnt;
        }
    }
}
