using System;
using BenchmarkDotNet.Attributes;
using NickBuhro.Translit.Sandbox.v1;

namespace NickBuhro.Translit.Benchmark
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        private string _cyrillic;
        private string _latin;

        [Params("Small", "Big")]
        public string Asset;
        
        [GlobalSetup]
        public void Setup()
        {
            if (Asset == "Big")
            {
                _cyrillic = Assets.BigCyrillic;
                _latin = Assets.BigLatin;
            }
            else if (Asset == "Small")
            {
                _cyrillic = Assets.SmallCyrillic;
                _latin = Assets.SmallLatin;
            }
            else
            {
                throw new NotSupportedException();
            }
        }

        [Benchmark]
        public string C2L() => Transliteration.CyrillicToLatin(_cyrillic, Language.Russian);

        [Benchmark]
        public string L2C() => Transliteration.LatinToCyrillic(_latin, Language.Russian);

        [Benchmark(Baseline = true)]
        public string C2Lv1() => new CyrillicToLatinConverter(_cyrillic, Language.Russian).Convert();
    
        [Benchmark]
        public string L2Cv1() => new LatinToCyrillicConverter(_latin, Language.Russian).Convert();        
    }
}
