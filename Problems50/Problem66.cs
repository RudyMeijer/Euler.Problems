using System.Drawing;
using System;
using System.Collections.Generic;

namespace Euler.Solutions
{
	/// <summary>
	/// see http://projecteuler.net/index.php?section=problems&id=66
	///
	/// analyse: solve x2 – Dy2 = 1
	/// 
	/// performance improvements: use Chakravala method http://en.wikipedia.org/wiki/Chakravala_method.
	///</summary>
	class Problem66 : Helper, IProblem
	{
		public double Execute()
		{
			var sum = 0.0;
			var list = new long[1001];
			for (int D = 1; D <= 1000; D++)
			{
                Console.WriteLine($"D={D}");
				var sqr = Math.Sqrt(D);
				if (sqr == (int)sqr) { list[D] = -1; continue; } // D is kwadratic.
				if (list[D] == 0)
				{

					var m = new Triple(D);
					while (Math.Abs(m.k) != 1)
					{
						m = m.M();
					}
					// solution found;
					list[D] = m.a;
					sum = 1.0 * m.a / m.b;
				}
			}
			return sum;
		}


	}
	/// <summary>
	/// x.x-N.y.y = k
	/// </summary>
	class Triple
	{
		public long a;
		public long b;
		public long k;
		public long N;
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
			this.N = (a * a - k) / (b * b);
		}
		public Triple M()
		{
			//
			// bepaal m: (a+m) deelbaar door k en (m.m - N)/k is minimaal.
			//
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
				a1 = u * u + ((k1==2)?-1:+1);
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
			return String.Format("{0}, {1}, {2}, N={3}", a, b, k, N);
		}
	}
}

//private void make(dynamic triple, Tuple<int, int, int> triple1)
//{
//    var a = triple.a;
//    var b = triple.b;
//    var c = triple.k;
//    var r = a * c;
//}
//public double Execute1()
//{
//    var sum = 0.0;
//    var list = new long[1001];
//    for (int D = 1; D <= 1000; D++)
//    {
//        var sqr = Math.Sqrt(D);
//        if (sqr == (int)sqr) { list[D] = -1; continue; } // D is kwadratic.
//        if (list[D] == 0)
//        {
//            Console.WriteLine("D={0}", D);
//            //var Dyy = new Dictionary<int, long>();
//            var y = 0L;
//            var x = 0.5;
//            bool odd = false;
//            while ((x != (long)x) || !odd)
//            {
//                ++y;
//                x = Math.Sqrt(-4 + D * y * y);
//                odd = ((long)x & 1) > 0 && ((long)y & 1) > 0;
//            }
//            //
//            // found a minimum x.
//            //
//            list[D] = (long)x;
//        }
//    }
//    //
//    // find D where x is maximum.
//    //
//    var maxx = 0l;
//    for (int D = 0; D <= 1000; D++) if (list[D] > maxx) { maxx = list[D]; maxD = D; }
//    sum = maxD;
//    var r1 = long.MaxValue;
//    var X = list[maxD];
//    var XX = X * X;
//    long Y = 78104745;// (long)Math.Sqrt((X * X - 1) / maxD);// 20568;
//    var YY = Y * Y;
//    var DYY = maxD * YY;
//    var r = X * X - maxD * Y * Y;
//    return sum;
//}
////for (int x = 2; x < 1000000000; x++)
//{
//    int y; long r = 2;
//    long xx = (long)x * x;
//    if (xx < 0) break;
//    for (y = (int)(x / sqr); ; y++)
//    {
//        if (!Dyy.ContainsKey(y))
//        {
//            if (Dyy.Count >= 10) Dyy.Clear();
//            Dyy[y] = (long)D * y * y;
//        }
//        r = xx - Dyy[y];
//        if (r < 1) break; //this loop.
//        if (r == 1)
//        {
//            //
//            // found a minimum x.
//            //
//            list[D] = x;
//            break;
//        }
//    }
//    if (r == 1) break;
//            }
//        }
//    }
//    //
//    // find D where x is maximum.
//    //
//    //maxx = 0;
//    //for (int D = 0; D <= 1000; D++) if (list[D] > maxx) { maxx = list[D]; maxD = D; }
//    //sum = maxD;
//    return sum;
//}
