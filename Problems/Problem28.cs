namespace Euler.Solutions
{
    /// <summary>
    /// Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:
    ///                         21 22 23 24 25
    ///                         20  7  8  9 10
    ///                         19  6  1  2 11
    ///                         18  5  4  3 12
    ///                         17 16 15 14 13
    /// It can be verified that the sum of the numbers on the diagonals is 101.
    /// What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
    ///                                
    /// Solution:
    /// 
    /// Numbers on diagonaal NE: n²  where n is size of spiral 3, 5, 7... 1001 
    /// Numbers on diagonaal SE: n² -3n + 3
    /// Sum = 2 * (NE + SE) + 1 
    /// 
    /// </summary>
    /// <returns></returns>
    class Problem28 : IProblem
    {
        //
        // Solution 2:
        // 
        // Numbers on diagonaal NE: n² where n is size of spiral 3, 5, 7... 1001 
        // Numbers on diagonaal SE: n² -3n + 3
        // Sum = 2 * (NE + SE) + 1 
        //
        public double Execute() // 2 us.
        {
            int sum = 1;
            for (int n = 1; n <= 500; n++)
            {
                sum += (4 * n * n + n + 1) << 2;
            }
            return sum;
        }
        //
        // Solution 1:
        //
        // s = spiral number            : 1  2  3  4  5 ... 501
        // r = ribbe length   (2*s-1)   : 1  3  5  7  9
        // d = numbers/spiral 4*(r-1)   : 0  8 16 24 32
        // e = numbers cummulative(e+=d): 1  9 25 49 81 <= diag North-East
        // f = diag South-East (e-d+r-1): 1  3 13 31 57 <= e-6s+6
        // 
        // Sum = 2 * (NE + SE) - 3
        // 
        public double ExecuteLinq() // 6 ms.
        {
            int sum = 1;
            var s = Enumerable.Range(1, 501);
            var r = from x in s select 2 * x - 1;
            var d = from x in r select 4 * (x - 1);
            var e = (from x in d.Select(x => sum += x) select x).ToArray();
            var f = from x in e.Select((x, i) => x - 6 * (i + 1) + 6) select x;

            return 2 * (e.Sum() + f.Sum()) - 3;
        }
    }
}
