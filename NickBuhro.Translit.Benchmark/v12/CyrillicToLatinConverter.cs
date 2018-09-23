using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NickBuhro.Translit.Benchmark.v12
{
    public partial struct CyrillicToLatinConverter
    {
        private readonly Language _lang;
        private readonly string _src;
        private readonly Dictionary<char, string> _ruleSet;

        private StringBuilder _sb;
        
        /// <summary>
        /// Create an instance of algorithm.
        /// </summary>
        public CyrillicToLatinConverter(string source, Language lang)
        {
            Debug.Assert(Language.Unknown == 0);
            Debug.Assert((int)Language.Russian == 1);
            Debug.Assert((int)Language.Belorussian == 2);
            Debug.Assert((int)Language.Ukrainian == 3);
            Debug.Assert((int)Language.Bulgarian == 4);
            Debug.Assert((int)Language.Macedonian == 5);
            
            _ruleSet = Rules[(int)lang];
            _lang = lang;
            _src = source;
            _sb = null;
        }

        /// <summary>
        /// Should be invoked only once.
        /// </summary>
        public string Convert()
        {
            Debug.Assert(_src != null);
            Debug.Assert(_ruleSet != null);

            if (string.IsNullOrEmpty(_src))
                return _src;

            _sb = new StringBuilder();

            for (var srcIndex = 0; srcIndex < _src.Length; srcIndex++)
            {
                string substitute;
                if (_ruleSet.TryGetValue(_src[srcIndex], out substitute))
                {
                    var nextChar = (_src.Length > (srcIndex + 1)) ? _src[srcIndex + 1] : ' ';
                    substitute = CheckSpecificRules(substitute, nextChar);
                    _sb.Append(substitute);
                }
                else
                {
                    _sb.Append(_src[srcIndex]);
                }
            }

            return _sb.ToString();
        }
                
        private string CheckSpecificRules(string substitue, char nextSourceChar)
        {
            // Ц	cz, c	cz, c	cz, c	cz, c	cz, c	рекомендуется использовать С перед буквами I, Е, Y, J; в остальных случаях CZ
            if ((substitue.Length != 2) || (substitue[1] != 'z'))
                return substitue;            
            
            switch (nextSourceChar)
            {
                case 'Е':
                case 'Ё':
                case 'И':
                case 'Й':
                case 'I':
                case 'Ы':
                case 'Э':
                case 'Ю':
                case 'Я':
                case 'е':
                case 'ё':
                case 'и':
                case 'й':
                case 'i':
                case 'ы':
                case 'э':
                case 'ю':
                case 'я':
                case 'ѣ':
                case 'Ѣ':
                case 'ѵ':
                case 'Ѵ':
                    return substitue.Substring(0, 1);                    
                default:
                    return substitue;                    
            }            
        }
    }
}
