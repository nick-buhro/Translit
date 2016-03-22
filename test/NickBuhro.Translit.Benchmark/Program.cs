using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime;

namespace NickBuhro.Translit.Benchmark
{
    public class Program
    {
        public static void Main()
        {
            long seed = Environment.TickCount;
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            Console.WriteLine("Cyrillic to Latin # 1");
            ExecuteTest(() => Transliteration.CyrillicToLatin(TestCase.Value, Language.Russian));

            Console.WriteLine("Latin to Cyrillic # 1");
            ExecuteTest(() => Transliteration.LatinToCyrillyc(TestCase.Value, Language.Russian));

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static void ExecuteTest(Action func)
        {
            const int I = 5;
            const int N = 100;
            
            var elapsed = new long[I];
            var mem = new long[I];
            
            var latencyMode = GCSettings.LatencyMode;

            var sw = new Stopwatch();
            for (var i = 0; i < I; i++)
            {   
                sw.Reset();
                func();

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GCSettings.LatencyMode = GCLatencyMode.LowLatency;

                var memBefore = GC.GetTotalMemory(false);
                             
                sw.Start();

                for (var j = 1; j < N; j++)
                {
                    func();
                }
 
                sw.Stop();

                elapsed[i] = sw.ElapsedMilliseconds;
                mem[i] = GC.GetTotalMemory(false) - memBefore;
                GCSettings.LatencyMode = latencyMode;
            }
            
            for (var i = 0; i < I; i++)
            {
                Console.WriteLine("    {0,5:0.00} ms {1,12:# ##0} B", (double)elapsed[i]/N, mem[i]/N);
            }
            Console.WriteLine("AVG {0,5:0.00} ms {1,12:# ##0} B", (double)elapsed.Sum() / I / N, mem.Sum() / I / N);
            Console.WriteLine();
        }        
    }
}
