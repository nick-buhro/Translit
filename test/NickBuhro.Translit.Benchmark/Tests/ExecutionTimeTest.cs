using System;
using System.Diagnostics;
using System.Runtime;

namespace NickBuhro.Translit.Benchmark
{
    public static class ExecutionTimeTest
    {
        /// <summary>
        /// Execute test with time measurement.
        /// </summary>
        /// <param name="testAction">Action for measurement.</param>
        /// <param name="n">Repeat count.</param>
        /// <returns>Average time in milliseconds.</returns>
        public static double Execute(Action testAction, int n = 30)
        {
            // Cold run
            testAction();

            // Full garbage collection
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            // Set low latency GC mode (suppress gen2 garbage collection)
            var latencyMode = GCSettings.LatencyMode;
            GCSettings.LatencyMode = GCLatencyMode.LowLatency;

            try
            {
                // Run timer
                var sw = new Stopwatch();
                sw.Start();

                // Execute test n-times
                for (var i = 0; i < n; i++)
                {
                    testAction();
                }

                // Return result
                sw.Stop();
                return (double)sw.ElapsedMilliseconds / n;
            }
            finally
            {
                // Recovery initial latency mode
                GCSettings.LatencyMode = latencyMode;
            }
        }
    }
}
