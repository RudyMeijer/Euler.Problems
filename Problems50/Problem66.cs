using System;
using Big = System.Numerics.BigInteger; // Essentieel voor grote getallen

namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=66
    ///
    /// analyse: solve x² – Dy² = 1
    /// 
    /// performance improvements: use Chakravala method http://en.wikipedia.org/wiki/Chakravala_method.
    ///</summary>

    class Problem66 : Helper, IProblem
    {
        int limit = 1000;
        int resultD = 0;
        Big maxX = 0;
        public double Execute()
        {
            for (int D = 2; D <= limit; D++)
            {
                // Stap 1: Check of D een perfect kwadraat is
                int limitSqrt = (int)Math.Sqrt(D);
                if (limitSqrt * limitSqrt == D)
                    continue;

                // Variabelen voor de kettingbreuk (Continued Fraction)
                Big m = 0;
                Big d = 1;
                Big a = limitSqrt;

                // Variabelen voor convergenten (h/k)
                // We gebruiken een iteratieve methode: h_n = a * h_{n-1} + h_{n-2}
                // Startwaarden (zodat de eerste iteratie correct a/1 oplevert):
                Big num1 = 1; // Teller (x) vorige stap (n-1)
                Big num2 = 0; // Teller (x) stap daarvoor (n-2)

                Big den1 = 0; // Noemer (y) vorige stap (n-1)
                Big den2 = 1; // Noemer (y) stap daarvoor (n-2)

                while (true)
                {
                    // Bereken de nieuwe x (teller) en y (noemer)
                    Big x = a * num1 + num2;
                    Big y = a * den1 + den2;

                    // Controleer de Pell vergelijking: x^2 - D*y^2 = 1
                    if ((x * x) - (D * y * y) == 1)
                    {
                        // Oplossing gevonden voor deze D
                        if (x > maxX)
                        {
                            maxX = x;
                            resultD = D;
                        }
                        break; // Ga naar de volgende D
                    }

                    // Update de geschiedenis van x en y voor de volgende iteratie
                    num2 = num1;
                    num1 = x;

                    den2 = den1;
                    den1 = y;

                    // Bereken de volgende termen van de kettingbreuk (m, d, a)
                    // Volgorde is belangrijk hier!
                    m = d * a - m;
                    d = (D - m * m) / d;
                    a = (limitSqrt + m) / d;
                }
            }

            //Console.WriteLine("--------------------------------------------------");
            //Console.WriteLine($"De waarde van D met de grootste x is: {resultD}");
            //Console.WriteLine($"De bijbehorende x is: {maxX}");
            return resultD;
        }
    }
    class Prxoblem66 : Helper, IProblem
    {
        public double Execute()
        {
            var sum = 0.0;
            var list = new long[1001];
            for (int D = 2; D <= 1000; D++)
            {
                //Console.WriteLine($"D={D}");
                var sqr = Math.Sqrt(D);
                if (sqr == (int)sqr) { list[D] = -1; continue; } // D is kwadratic.
                if (list[D] == 0)
                {

                    Triple m = new(D);
                    while (m.k != 1)
                    {
                        m = m.M();
                    }
                    // solution found;
                    list[D] = m.a;
                    Console.WriteLine($"m= {m}");
                    sum = 1.0 * m.a / m.b;
                }
            }
            return sum;
        }
    }
    /// <summary>
    /// a²-N.b² = k
    /// </summary>
    class Triple
    {
        public long a, b, k, N;
        public Triple(int N)
        {
            a = (int)(Math.Sqrt(N) + 0.5);
            b = 1;
            k = a * a - N;
            this.N = N;
        }
        public Triple(long a, long b, long k)
        {
            this.a = a;
            this.b = b;
            this.k = k;
            this.N = (long)((Math.Pow(a, 2) - k) / Math.Pow(b, 2));
        }
        /// <summary>
        /// 
        /// bepaal m: (a+m) deelbaar door k en (m² - N)/k is minimaal.
        /// 
        /// </summary>
        public Triple M()
        {
            var m = (int)(Math.Sqrt(N) - 1);
            var remainder1 = 1L;
            var remainder2 = 1L;
            while (remainder1 != 0 || remainder2 != 0)
            {
                ++m;
                Math.DivRem(m * m - N, k, out remainder1);
                Math.DivRem(a + b * m, k, out remainder2);
            }
            var k_ = Math.Abs(k);
            var a1 = (a * m + N * b) / k_;
            var b1 = (a + b * m) / k_;
            var k1 = (m * m - N) / k;
            if (Math.Abs(k1) == 2)
            {
                var u = a1;
                a1 = u * u + ((k1 == 2) ? -1 : +1);
                b1 = u * b1;
                k1 = 1;
            }
            if (Math.Abs(k1) == 4)
            {
                var u = a1;
                a1 = (u * u * u * u + 4 * u * u + 1) * (u * u + 2) / 2;
                b1 = (u * u + 3) * (u * u + 1) * u * b1 / 2;
                k1 = 1;
            }
            return new Triple(a1, b1, k1);
        }
        public Triple Compose(Triple t)
        {
            var a1 = (a * t.a + N * b * t.b);
            var b1 = (a * t.b + t.a * b);
            var k1 = k * t.k;
            return new Triple(a1 / k, b1 / k, k1 / k);
        }
        public override string ToString()
        {
            return String.Format($"{a,5}, {b,5}, N={N}");
        }
    }
}
