namespace Euler.Solutions
{
    /// <summary>
    /// see http://projecteuler.net/index.php?section=problems&id=341
    ///
    /// analyse:
    /// 
    /// performance improvements:
    ///</summary>
    class xProblem341 : Helper, IProblem
    {
        public double Execute()
        {
            //double a = F(1);

            double s = (F(999) + F(1000)) / 2; //ΣG(n^3) = 153506976 for 1 <= n < 10^3.
            return s;
        }
        public double Execute1()
        {
            double sum = 0;
            //Console.WriteLine("G(1e+3)={0}", G(1e+3));
            //Console.WriteLine("G(1e+6)={0}", G(1e+6));
            for (int i = 1; i < 50; i++)
            {
                int n = i;// (int)Math.Pow(i, 3);
                sum += G(n);
                Console.WriteLine("G({0})={1} sum={2}", n, G(n), sum);
            }
            //int sum1 = 153506976;
            //long G1E_6_1_3 = 160113493649; //G((10^6-1)^3) = 160113493649
            //long G1E_5_1_3 = 2240166964;
            //double sum3 = G(Math.Pow(1e+5 - 1, 3));
            return sum;
        }
        //
        // f(x)= a.x^b where x = n^3
        // f(n)= a.n^(3*b)
        // Integraal F(x) = a/(b+1) * x^(b+1)
        // Integraal F(n) = a/(3b+1) * n^(3b+1) 
        private static double F(int n)
        {
            //int good = 153506976;
            double a = 1.201783329306916;  //Q^(2 - Q) where golden ratio Q = (sqrt(5)+1)/2
            double b = 0.6180339887498949; //Q - 1
            double integraal = (a * Math.Pow(n, (3 * b + 1)) / (3 * b + 1));
            return integraal;
        }
        //private double Ginv(int n)
        //{
        //    double sum = 0;
        //    for (int i = 0; i < n; i++)
        //    {
        //        sum += G(i);
        //    }
        //    return sum;
        //}
        //public double Execute2()
        //{
        //    List<int> G = new();
        //    G.AddRange(new int[] {0,1,2,2});
        //    for (int n = 3; n <= 88; n++) for (int i = 0; i < G[n]; i++) G.Add(n);

        //    for (int i = 0; i < G.Count; i++)
        //    {
        //        //if (G[i] != this.G(i)) Console.Write("*");
        //        Console.WriteLine($"G[{i}]={G[i]}");
        //    }
        //    return 0;
        //}
        public double Xexecute1()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("G({0})={1}", i, G(i));
            }
            return 0;
        }
        //
        // a(1) = 1; a(n + 1) = 1 + a(n + 1 − a(a(n)))
        //
        private double G(double n)
        {
            //double Q = (Math.Sqrt(5) + 1) / 2; //Golden ratio.
            //return (int)(Math.Pow(Q, 2 - Q) * Math.Pow(n, Q - 1)+0.50);
            //return (int)(1.201783329306916 * Math.Pow(n, 0.6180339887498949)+0.5);
            //return (int)(1.20178 * Math.Pow(n, 0.618032)+0.5);
            if (n <= 1) return 1;
            return 1 + G(n - G(G(n - 1)));
            //wrong !return G(n - G(n - 1)) + 1;


        }
    }
}
