using System.Drawing;

namespace Euler.Solutions
{
	/// <summary>
	/// see http://projecteuler.net/index.php?section=problems&id=65
	///
	///                   N(n)                1                D(n-1)    I(n) * N(n-1) + D(n-1)
	/// analyse: Sqr(2) = ---- = I(n) + ------------- = I(n) + ------ =  ---------------------- 
	///                   D(n)          N(n-1)/D(n-1)          N(n-1)           N(n-1)
	/// 
	/// so:  N(n) = I(n) * N(n-1) + D(n-1) }--> I(n) * N(n-1) + N(n-2)
	///      D(n) = N(n-1)                 }   
	/// 
	/// performance improvements: Add cache improves from 9999 hours -> 3 ms.
	///</summary>
	class Problem65 : Helper, IProblem
	{
		private const int MAXPLY = 100;
		private Point[] points = new Point[10];
		private System.Numerics.BigInteger[] cache = new System.Numerics.BigInteger[MAXPLY + 1]; 

		public double Execute()
		{
			var sum = Helper.SumDigits(Numerator(MAXPLY));
			return sum;
		}

		private System.Numerics.BigInteger Numerator(int ply)
		{
			if (ply == 0) return 1;
			if (ply == -1) return 0;
			if (cache[ply] > 0) return cache[ply];
			var numerator = integer(ply) * Numerator(ply - 1) + Numerator(ply - 2);
			cache[ply] = numerator;
			return numerator;
		}
		//
		// Create sequence [2;1,2,1,1,4,1,1,6,1]
		//
		private int integer(int ply)
		{
			//if (ply == 2) return 66;
			//if (ply <= 4) return 1;

			var p = MAXPLY - ply + 1;
			if (p == 1) return 2;
			var i = (p % 3 == 0) ? 2 * p / 3 : 1;
			return i;
		}
	}
}
