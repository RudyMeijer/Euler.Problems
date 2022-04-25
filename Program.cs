using System;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.IO;

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
                           where Problem.Name.StartsWith("Problem") // Remove number to execute all tests.
                           orderby  Problem.Name ascending select Problem;
            ///
            /// Execute each problem and show results.
            ///
            foreach (var Problem in Problems)
            {
                IProblem problem = (IProblem)Activator.CreateInstance(Problem);
                UnitTest.Pass(problem,1);
                Console.WriteLine("{0,-9} ={1,12} elapsed time:{2,5} ms. Test {3}.", Problem.Name, UnitTest.result, UnitTest.ElapsedMilliseconds, UnitTest.passed?"Passed":"Failed !!!");
                //break; // only execute last problem
            }
            Console.WriteLine("Total Time: {0} ms",UnitTest.TotalTime);
			//Helper : 2 ms.                      .net 4.0
			//Problem00 =          -1 elapsed time:    4 ms. Test Passed.    3 ms.
			//Problem01 =      233168 elapsed time:    1 ms. Test Passed.    1 ms.
			//Problem02 =     4613732 elapsed time:    6 ms. Test Passed.    1 ms.
			//Problem03 =        6857 elapsed time:  111 ms. Test Passed.   58 ms.
			//Problem04 =      906609 elapsed time:    2 ms. Test Passed.    1 ms.
			//Problem05 =   232792560 elapsed time:   11 ms. Test Passed.  102 ms.
			//Problem06 =    25164150 elapsed time:    0 ms. Test Passed.    2 ms.
			//Problem07 =      104743 elapsed time:    0 ms. Test Passed.    8 ms.
			//Problem08 =       40824 elapsed time:    0 ms. Test Passed.    0 ms.
			//Problem09 =    31875000 elapsed time:    1 ms. Test Passed.    0 ms.
			//Problem10 =142913828922 elapsed time:  144 ms. Test Passed.   70 ms.
			//Problem11 =    70600674 elapsed time:    1 ms. Test Passed.    0 ms.
			//Problem12 =    76576500 elapsed time:   81 ms. Test Passed.   56 ms.
			//Problem13 =  5537376230 elapsed time:    3 ms. Test Passed.    2 ms.
			//Problem14 =      837799 elapsed time:   81 ms. Test Passed.  139 ms.
			//Problem15 =137846528820 elapsed time:    0 ms. Test Passed.    0 ms.
			//Problem16 =        1366 elapsed time:    8 ms. Test Passed.    4 ms.
			//Problem17 =       21124 elapsed time:    5 ms. Test Passed.    4 ms.
			//Problem18 =        1074 elapsed time:    1 ms. Test Passed.    0 ms.
			//Problem19 =         171 elapsed time:    1 ms. Test Passed.    1 ms.
			//Problem20 =         648 elapsed time:    9 ms. Test Passed.    3 ms.
			//Problem21 =       31626 elapsed time:    8 ms. Test Passed.    4 ms.
			//Problem22 =   871198282 elapsed time:   32 ms. Test Passed.   23 ms.
			//Problem23 =     4179871 elapsed time:  191 ms. Test Passed.  123 ms.
			//Problem24 =  2783915460 elapsed time:    1 ms. Test Passed.   29 ms.
			//Problem25 =        4782 elapsed time:    0 ms. Test Passed.
			//Problem26 =         983 elapsed time:    2 ms. Test Passed.
			//Problem27 =      -59231 elapsed time:   11 ms. Test Passed.
			//Problem28 =   669171001 elapsed time:    0 ms. Test Passed.
			//Problem29 =        9183 elapsed time:   25 ms. Test Passed.
			//Problem30 =      443839 elapsed time:   27 ms. Test Passed.
			//Problem31 =       73682 elapsed time:    3 ms. Test Passed.
			//Problem32 =       45228 elapsed time:   11 ms. Test Passed.
			//Problem33 =         100 elapsed time:    0 ms. Test Passed.
			//Problem34 =       40730 elapsed time:    5 ms. Test Passed.
			//Problem35 =          55 elapsed time:   11 ms. Test Passed.
			//Problem36 =      872187 elapsed time:    4 ms. Test Passed.
			//Problem37 =      748317 elapsed time:   16 ms. Test Passed.
			//Problem38 =   932718654 elapsed time:    1 ms. Test Passed.
			//Problem39 =         840 elapsed time:    1 ms. Test Passed.
			//Problem40 =         210 elapsed time:    1 ms. Test Passed.
			//Problem41 =     7652413 elapsed time:    2 ms. Test Passed.
			//Problem42 =         162 elapsed time:   23 ms. Test Passed.
			//Problem43 = 16695334890 elapsed time:   20 ms. Test Passed.
			//Problem44 =     5482660 elapsed time:    4 ms. Test Passed.
			//Problem45 =  1533776805 elapsed time:    3 ms. Test Passed.
			//Problem46 =        5777 elapsed time:   19 ms. Test Passed.
			//Problem47 =      134043 elapsed time:  165 ms. Test Passed.
			//Problem48 =  9110846700 elapsed time:   19 ms. Test Passed.
			//Problem49 =296962999629 elapsed time:    5 ms. Test Passed.
			//Problem50 =      997651 elapsed time:    1 ms. Test Passed.
			//Problem51 =      121313 elapsed time:   19 ms. Test Passed.
			//Problem52 =      142857 elapsed time:   11 ms. Test Passed.
			//Problem53 =        4075 elapsed time:    0 ms. Test Passed.
			//Problem54 =         376 elapsed time:   16 ms. Test Passed.
			//Problem55 =         249 elapsed time:    5 ms. Test Passed.
			//Problem56 =         972 elapsed time:   24 ms. Test Passed.
			//Problem57 =         153 elapsed time:    1 ms. Test Passed.
			//Problem58 =       26241 elapsed time:  239 ms. Test Passed.
			//Problem59 =      107359 elapsed time:   59 ms. Test Passed.
			//Problem60 =       26033 elapsed time:  421 ms. Test Passed.
			//Problem61 =       28684 elapsed time:    3 ms. Test Passed.
			//Problem62 =127035954683 elapsed time:   48 ms. Test Passed.
			//Problem63 =          49 elapsed time:    0 ms. Test Passed.
			//Problem64 =        1322 elapsed time:   16 ms. Test Passed.
			//Problem65 =         272 elapsed time:    3 ms. Test Passed.
			//Total Time: 1946 ms
			//Press any key to continue . . .
        }
        public static void ConsoleWriteToFile(string outputFile)
        {
            StreamWriter sw = new StreamWriter(outputFile);
            sw.AutoFlush=true;
            Console.SetOut(sw);
        }
    }
    interface IProblem
    {
        double Execute();
    }
}
