using System.Reflection;
using System.Diagnostics;

namespace Euler.Solutions
{
    /// <summary>
    /// This program generates solutions for the Euler problems on site:
    /// http://projecteuler.net/index.php?section=problems
    /// 
    /// All timing measured on @Intel Core Duo P8600 2.4 Ghz
    /// 
    /// Author: Rudy Meijer
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //ConsoleWriteToFile("Problems 1 - 65 .net4.0.log");
            Fibonacci.UnitTest();
            //BigInteger.UnitTest();
            PrimeNumberSieve.UnitTest();
            Palindrome.UnitTest();
            Extensions.UnitTest();
            Helper.UnitTest();
            ///
            /// Find all problem classes in this assembly.
            /// 
            var Problems = from Problem in Assembly.GetExecutingAssembly().GetTypes()
                           where Problem.Name.StartsWith("Problem69") // Remove number to execute all tests.
                           orderby Problem.Name ascending
                           select Problem;
            ///
            /// Execute each problem and show results.
            ///
            foreach (var Problem in Problems)
            {
                IProblem problem = (IProblem)Activator.CreateInstance(Problem);
                UnitTest.Pass(problem, 1);
                Console.WriteLine("{0,-9} ={1,12} elapsed time:{2,5} ms. Test {3}.", Problem.Name, UnitTest.result, UnitTest.ElapsedMilliseconds, UnitTest.passed ? "Passed" : "Failed !!!");
                //break; // only execute last problem
            }
            Console.WriteLine("Total Time: {0} ms", UnitTest.TotalTime);
            
            // Benchmark baseline vs optimized Problem60
            //try
            //{
            //    const int iterations = 3;
            //    var baselineTimes = new List<long>();
            //    var optimizedTimes = new List<long>();
            //    double baselineResult = 0, optimizedResult = 0;

            //    // baseline
            //    for (int i = 0; i < iterations; i++)
            //    {
            //        var p = new Problem60Baseline();
            //        var sw = Stopwatch.StartNew();
            //        baselineResult = p.Execute();
            //        sw.Stop();
            //        baselineTimes.Add(sw.ElapsedMilliseconds);
            //        Console.WriteLine($"Baseline Problem60 run {i + 1}: result={baselineResult} time={sw.ElapsedMilliseconds} ms");
            //    }

            //    // optimized
            //    for (int i = 0; i < iterations; i++)
            //    {
            //        var p = new Problem60();
            //        var sw = Stopwatch.StartNew();
            //        optimizedResult = p.Execute();
            //        sw.Stop();
            //        optimizedTimes.Add(sw.ElapsedMilliseconds);
            //        Console.WriteLine($"Optimized Problem60 run {i + 1}: result={optimizedResult} time={sw.ElapsedMilliseconds} ms");
            //    }

            //    Console.WriteLine($"Baseline average: {baselineTimes.Average()} ms, Optimized average: {optimizedTimes.Average()} ms");
            //    Console.WriteLine($"Speedup factor: {baselineTimes.Average() / optimizedTimes.Average():F2}x");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Benchmark failed: {ex.Message}");
            //}
        }
        public static void ConsoleWriteToFile(string outputFile)
        {
            StreamWriter sw = new(outputFile);
            sw.AutoFlush = true;
            Console.SetOut(sw);
        }
    }
    interface IProblem
    {
        double Execute();
    }
}
