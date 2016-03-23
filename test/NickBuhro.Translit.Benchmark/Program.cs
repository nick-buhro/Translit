using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace NickBuhro.Translit.Benchmark
{
    public class Program
    {
        public static void Main()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            ExecuteTest(
                "Cyrillic to Latin",
                TestCase.Cyrillic.Length,
                () => Transliteration.CyrillicToLatin(TestCase.Cyrillic, Language.Russian));

            ExecuteTest(
                "Latin to Cyrillic",
                TestCase.Latin.Length,
                () => Transliteration.LatinToCyrillyc(TestCase.Latin, Language.Russian));

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static void ExecuteTest(string testName, int srcLength, Action testAction)
        {
            Console.WriteLine(testName);
            Console.WriteLine();

            Console.WriteLine("    Source length:{0,9:# ### ### ##0} chars", srcLength);
            Console.WriteLine("                  {0,9:# ### ### ##0} B", srcLength << 1);
            Console.WriteLine();

            var t = new double[5];
            for (var i = 0; i < t.Length; i++)
            {
                t[i] = ExecutionTimeTest.Execute(testAction);
                Console.Write("    {0,5:0.00} ms", t[i]);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("    Avg time:    {0,10:0.00} ms", t.Sum() / t.Length);
            Console.WriteLine("    Mem traffic: {0,10:# ### ### ##0} B", MemoryTrafficTest.Execute(testAction));

            Console.WriteLine();
        }        
    }
}
