using System.Collections;
using System.Diagnostics;

namespace Euler.Solutions
{
    /// <summary>
    /// This class generates the Fibonacci sequence: 1,2,3,5,8,13,21,34,55,... 1134903170
    /// </summary>
    public class Fibonacci : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            int f1 = 0, f2 = 1, f3 = 0;
            while (f3 < int.MaxValue / 2)
            {
                f3 = f1 + f2;
                yield return f3;
                f1 = f2; f2 = f3;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public static void UnitTest()
        {
            var result = from v in new Fibonacci()
                         select v;
            int cnt = result.Last(); // 1134903170
            double sum = result.Average();
            Debug.Assert(sum == 67527615.25, "Unittest failed: Fibonacci error");
        }

    }
}
