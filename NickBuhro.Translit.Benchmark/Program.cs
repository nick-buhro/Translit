using BenchmarkDotNet.Running;
using System;

namespace NickBuhro.Translit.Benchmark
{
    public static class Program
    {
        public static void Main()
        {
            var summary = BenchmarkRunner.Run<Benchmark>();
            Console.WriteLine(summary);
            Console.ReadKey();
        }
    }
}
