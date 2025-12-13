using Euler.Solutions;
using System;
using System.Collections.Generic;
using System.Text;

//namespace Euler.Problems.Problems50;
/// <summary>
/// https://projecteuler.net/problem=69
/// </summary>
class Problem69 : IProblem
{
    public double Execute()
    {
        var maxN = 0.0;
        var maxU = 0.0;
        for (int n = 2; n <= 1_000_000; n++)
        {
            int totient = Totient1(n);
            var u = (double)n / totient;
            //if (n % 1 == 0) Console.WriteLine($"Q({n}) ={totient,3}, n/Q(n) = {u}");

            if (u > maxU)
            {
                maxU = u;
                maxN = n;
            }
        }
        return maxN;
    }
    private int Totient(int maxn)
    {
        int sum = 1;
        for (int n = 2; n <= maxn; n++)
        {
            if (Helper.CoPrime(n, maxn))
            {
                sum += 1;
            }
        }
        return sum;
    }
    /// https://en.wikipedia.org/wiki/Euler%27s_totient_function#Example
    /// Q(20) = Q(2²5) = 20(1-½)(1-1/5) = 20 x ½ x 4/5 = 8
    /// In words: the distinct prime factors of 20 are 2 and 5; 
    /// half of the twenty integers from 1 to 20 are divisible by 2, leaving ten; 
    /// a fifth of those are divisible by 5, leaving eight numbers coprime to 20; 
    /// these are: 1, 3, 7, 9, 11, 13, 17, 19.
    /// 
    /// Implement https://cp-algorithms.com/algebra/phi-function.html
    private int Totient1(int n)
    {
        int result = n;
        for (int i = 2; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                while (n % i == 0)
                    n /= i;
                result -= result / i;
            }
        }
        if (n > 1)
            result -= result / n;
        return result;
    }
}