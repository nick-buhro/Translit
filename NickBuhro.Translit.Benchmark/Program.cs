using BenchmarkDotNet.Running;
using System;

namespace NickBuhro.Translit.Benchmark
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine(BenchmarkRunner.Run<Benchmark>());
            Console.WriteLine(BenchmarkRunner.Run<CustomStringBuilderBenchmark>());
            Console.ReadKey();
        }
    }
}
