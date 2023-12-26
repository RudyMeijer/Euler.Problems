namespace Euler.Solutions
{
    /// <summary>
    /// Find the maximum total from top to bottom of the triangle below:
    /// </summary>
    /// <returns></returns>
    class Problem18 : IProblem
    {
        public double Execute()
        {
            int result = total(0, 0);
            return result;
        }
        private int total(int y, int x)
        {
            if (y == 14) return triangle[y][x];
            if (max[y][x] == 0)
                max[y][x] = Math.Max(total(y + 1, x), total(y + 1, x + 1)) + triangle[y][x];
            return max[y][x];
        }
        public Problem18()
        {
            triangle = (from lines in striangle.Split('\r')
                        where lines.Length > 0
                        select (from bytes in (lines.Trim().Split(' '))
                                select int.Parse(bytes)).ToArray()).ToArray();
            max = (from y in triangle select (from x in y select 0).ToArray()).ToArray();
        }
        int[][] triangle, max;
        string striangle = @"
                      75
                     95 64
                    17 47 82
                   18 35 87 10
                  20 04 82 47 65
                 19 01 23 75 03 34
                88 02 77 73 07 63 67
               99 65 04 28 06 16 70 92
              41 41 26 56 83 40 80 70 33
             41 48 72 33 47 32 37 16 94 29
            53 71 44 65 25 43 91 52 97 51 14
           70 11 33 28 77 73 17 78 39 68 17 57
          91 71 52 38 17 14 91 43 58 50 27 29 48
         63 66 04 68 89 53 67 30 73 16 69 87 40 31
        04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";
    }
}
