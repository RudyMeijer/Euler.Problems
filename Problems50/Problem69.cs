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
            int totient = Totient(n);
            var u = (double)n / totient;
            if (n%1000==0) Console.WriteLine($"n={n}, totient = {totient}, n/totient = {u}");
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
}
