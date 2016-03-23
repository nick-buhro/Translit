using System;

namespace NickBuhro.Translit.Benchmark
{
    public static class MemoryTrafficTest
    {
        private const long _512MB = 1 << 29;

        public static long Execute(Action testAction, long memoryLimit = _512MB)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            if (!GC.TryStartNoGCRegion(memoryLimit))
                throw new InsufficientMemoryException();

            try
            {
                var memBefore = GC.GetTotalMemory(false);

                testAction();

                return GC.GetTotalMemory(false) - memBefore;
            }
            finally
            {           
                GC.EndNoGCRegion();
            }
        }
    }
}
