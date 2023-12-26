namespace Euler.Solutions
{
    /// <summary>
    /// The sum of the squares of the first ten natural numbers is, 1^2 + 2^2 + ... + 10^2 = 385
    /// The square of the sum of the first ten natural numbers is, (1 + 2 + ... + 10)^2 = 55^2 = 3025
    /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 - 385 = 2640.
    /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    ///</summary>
    /// <returns>25164150</returns>
    class Problem06 : IProblem
    {
        public double Execute()
        {
            var squares = from v in Enumerable.Range(1, 100) select v * v;
            var sum = Enumerable.Range(1, 100).Sum();
            return sum * sum - squares.Sum();
        }
        public double ExecuteBruteForce()
        {
            int sumOfSquares = 0, Sum = 0;
            for (int n = 1; n <= 100; n++)
            {
                sumOfSquares += n * n;
                Sum += n;
            }
            return Sum * Sum - sumOfSquares;
        }
    }
}
