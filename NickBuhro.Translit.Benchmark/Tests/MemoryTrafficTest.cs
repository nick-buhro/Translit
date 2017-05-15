using System;
using System.Runtime;

namespace NickBuhro.Translit.Benchmark
{
    public static class MemoryTrafficTest
    {
        public static long Execute(Action testAction)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var latencyMode = GCSettings.LatencyMode;
            GCSettings.LatencyMode = GCLatencyMode.LowLatency;

            try
            {
                var memBefore = GC.GetTotalMemory(false);

                testAction();

                return GC.GetTotalMemory(false) - memBefore;
            }
            finally
            {
                GCSettings.LatencyMode = latencyMode;
            }
        }
    }
}
