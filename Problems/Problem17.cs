namespace Euler.Solutions
{
    /// <summary>
    /// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
    /// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used? 
    /// NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.
    /// </summary>
    /// <returns></returns>
    class Problem17 : IProblem
    {
        public double Execute()
        {
            string[] words = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] words10 = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            var numbers_20_99 = from t in words10
                                from u in words.Take(10)
                                select (t + u);
            var numbers_1_99 = from n in words.Concat(numbers_20_99)
                               select n;
            var numbers_1_999 = from h in words.Take(10)
                                from n in numbers_1_99
                                select (h + ((h == "") ? "" : "hundred" + ((n == "") ? "" : "and")) + n);

            return numbers_1_999.Select(word => word.Length).Sum() + "onethousand".Length;
        }
    }
}
