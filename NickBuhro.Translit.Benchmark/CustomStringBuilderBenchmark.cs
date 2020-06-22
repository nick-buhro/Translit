using System;
using BenchmarkDotNet.Attributes;

namespace NickBuhro.Translit.Benchmark
{
    [MemoryDiagnoser]
    public class CustomStringBuilderBenchmark
    {
        private string _cyrillic;
        private string _latin;

        [Params(10, 100, 1000, 10000, 100000)]
        public int AssetSize;

        [Params("C2L", "L2C")]
        public string Direction;

        [GlobalSetup]
        public void Setup()
        {
            _cyrillic = Assets.BigCyrillic.Substring(0, AssetSize);
            _latin = Assets.BigLatin.Substring(0, AssetSize);
        }

        [Benchmark(Baseline = true)]
        public string GC() => Test(false);

        [Benchmark]
        public string AP() => Test(true);

        private string Test(bool arrayPooling)
        {
            return (Direction == "C2L")
                ? Transliteration.CyrillicToLatinRussian(_cyrillic, arrayPooling)
                : Transliteration.LatinToCyrillicRussian(_latin, arrayPooling);
        }
    }
}
