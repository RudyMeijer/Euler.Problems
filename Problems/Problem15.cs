using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Euler.Solutions
{
    /// <summary>
    /// Starting in the top left corner of a 2x2 grid, there are 6 routes (without backtracking) to the bottom right corner.
    /// How many routes are there through a 20x20 grid?
    ///
    /// Solution:
    /// Wanneer we het grid 20x20 met het eindpunt omhoog vastpakken, krijgen we 
    /// onderstaande driehoek:
    /// 
    ///                 1
    ///               1   1
    ///             1   2   1
    ///           1   3   3   1
    /// rij 4-> 1   4   6   4   1     
    ///       1   5  10   10  5   1
    ///     1   6  15   20  15  6   1
    ///   1   7   21  35  35  21  7   1
    /// 1   8   28  56  70  56  28  8   1
    ///
    /// De getallen in de driehoek geven het aantal wegen aan vanaf dat getal naar de top.
    /// Zo zijn vanuit het getal 2 precies twee wegen naar de top.
    /// Omdat er steeds 2 keuzes zijn om van een getal de weg naar de top te vervolgen is
    /// een getal gelijk aan som van beide bovenliggende getallen.
    /// Bovenstaande eigenschap komt overeen met de driehoek van Pascal.
    /// 
    /// De getallen in de driehoek kunnen we met de binominaal formule berekenen.
    /// 
    /// B(n/k) = n!/(k!*(n-k)!)
    /// 
    /// Hierin is rij n de macht en k de plaats v/d coefficienten in een n'e graads vergelijking.
    /// Voor een 4e graads vergelijking (a+b)^n krijgen we de coefficienten: 1 4 6 4 1
    /// 
    /// Het beginpunt voor een grid 2 x 2 is n=4 en k=2 -> aantal wegen is B(n/k)=4!/2!*2! = 6.
    /// Het beginpunt voor een grid 3 x 3 is n=6 en k=3 -> aantal wegen is B(n/k)=6!/3!*3! = 20.
    /// 
    /// </summary>
    /// <returns>137846528820</returns>
    class Problem15: IProblem
    {
        public double Execute() 
        {
            return Fac(40) / (Fac(20) * Fac(20));
        }

        private double Fac(int n)
        {
            if (n == 1) return 1;
            return n * Fac(n - 1);
        }
    }
}
