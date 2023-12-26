using System.Diagnostics;

namespace Euler.Solutions
{
    static class UnitTest
    {
        #region fields
        public static bool passed;
        public static double result;
        public static long ElapsedMilliseconds;
        public static long TotalTime;
        private static List<double> answers;
        #endregion
        /// <summary>
        /// UnitTest: 
        /// 
        /// Execute problem 'count' times. 
        /// Compare problem result with answer from textfile.
        /// </summary>
        /// <returns>
        /// result, passed, ElapsedMilliseconds
        /// </returns>
        public static void Pass(IProblem problem, int count)
        {
            if (answers == null) GetAnswers("text/Answers.txt");
            int nr = problem.ToString().Nr();
            var expected = answers[nr];
            Stopwatch s = Stopwatch.StartNew();
            while (count-- > 0) result = problem.Execute();
            ElapsedMilliseconds = s.ElapsedMilliseconds;
            TotalTime += ElapsedMilliseconds;
            passed = result == expected;
        }
        /// <summary>
        /// extract nummer at end of string.
        /// </summary>
        public static int Nr(this string s)
        {
            for (int i = s.Length - 3; i < s.Length; i++) if (Char.IsDigit(s[i])) return int.Parse(s[i..]);
            return 0;
        }
        /// <summary>
        /// Get answers from textfile answers.txt
        /// LINQ is used to get all answers from column 2 and convert them to a List<double>.
        /// </summary>
        private static void GetAnswers(string answerFile)
        {
            double temp;
            answers = (from line in File.ReadAllLines(answerFile)
                       where line.Contains(". ")
                       select double.TryParse(line.Substring(line.IndexOf(". ") + 2).Replace('.', ','), out temp) ? temp : -1).ToList();

            if (answers[307] != 0.7311720251)
                throw new FormatException("The file answers.txt contains wrong answers.");
        }
    }
}
