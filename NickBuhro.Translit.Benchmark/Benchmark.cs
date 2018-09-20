using System;
using BenchmarkDotNet.Attributes;
using NickBuhro.Translit.Benchmark.v12;
using NickBuhro.Translit.Benchmark.v13;

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


        [Benchmark(Baseline = true)]
        public string C2Lv12() => new CyrillicToLatinConverter(_cyrillic, Language.Russian).Convert();

        [Benchmark]
        public string L2Cv12() => new LatinToCyrillicConverter(_latin, Language.Russian).Convert();


        [Benchmark]
        public string C2Lv13() => FSMTranslit.CyrillicToLatin(_cyrillic, Language.Russian);

        [Benchmark]
        public string L2Cv13() => FSMTranslit.LatinToCyrillic(_latin, Language.Russian);


        [Benchmark]
        public string C2Lv14() => Transliteration.CyrillicToLatin(_cyrillic, Language.Russian);

        [Benchmark]
        public string L2Cv14() => Transliteration.LatinToCyrillic(_latin, Language.Russian);
    }
}
