using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler.Solutions
{
    /// <summary>
    /// You are given the following information, but you may prefer to do some research for yourself.
    /// 1 Jan 1900 was a Monday.
    /// Thirty days has September,
    /// April, June and November.
    /// All the rest have thirty-one,
    /// Saving February alone,
    /// Which has twenty-eight, rain or shine.
    /// And on leap years, twenty-nine. 
    /// A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
    /// 
    /// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
    /// </summary>
    /// <returns></returns>
    class Problem19: IProblem
    {
        public double Execute() // 757 us.
        {
            int sundays = 0;
            DateTime d1 = new DateTime(1901, 1, 1);
            DateTime d2 = new DateTime(2000, 12, 31);
            for (DateTime d = d1.AddDays(5); d < d2; d = d.AddDays(7)) if (d.Day == 1) 
            {
                sundays++;
            }
            return sundays;
        }
        public double ExecuteBruteForce() // 5373 us.
        {
            int sundays = 0;
            DateTime d1 = new DateTime(1901, 1, 1);
            DateTime d2 = new DateTime(2000, 12, 31);
            for (DateTime d = d1; d < d2; d = d.AddDays(1))
            {
                if (d.Day == 1 && d.DayOfWeek == DayOfWeek.Sunday) 
                {
                    sundays++;
                }
            }
            return sundays;
        }
    }
}
