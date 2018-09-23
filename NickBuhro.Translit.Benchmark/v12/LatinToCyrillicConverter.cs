using System.Diagnostics;

namespace NickBuhro.Translit.Benchmark.v12
{
    public partial struct LatinToCyrillicConverter
    {
        private readonly string _src;
        private readonly ConvertRule[] _ruleSet;
                
        /// <summary>
        /// Create an instance of algorithm.
        /// </summary>
        public LatinToCyrillicConverter(string source, Language lang)
        {
            Debug.Assert(Language.Unknown == 0);
            Debug.Assert((int)Language.Russian == 1);
            Debug.Assert((int)Language.Belorussian == 2);
            Debug.Assert((int)Language.Ukrainian == 3);
            Debug.Assert((int)Language.Bulgarian == 4);
            Debug.Assert((int)Language.Macedonian == 5);

            _ruleSet = Rules[(int)lang];
            _src = source;            
        }

        /// <summary>
        /// Detransliterate source. Should be invoked only once.
        /// </summary>
        /// <returns>Detransliterated cyrillic string.</returns>
        public string Convert()
        {
            Debug.Assert(_ruleSet != null);

            if (string.IsNullOrEmpty(_src))
                return _src;

            var result = _src;
            for (var i = 0; i < _ruleSet.Length; i++)
            {
                result = result.Replace(_ruleSet[i].Latin, _ruleSet[i].Cyrillic);
            }
            return result;
        }
    }
}
