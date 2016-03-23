using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NickBuhro.Translit.Implementation
{
    internal partial struct CyrillicToLatinConverter
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


        private static readonly HashSet<char> RuleCzCheck = new HashSet<char>
        {
            'Е', 'Ё', 'И', 'Й', 'I', 'Ы', 'Э', 'Ю', 'Я', 'е', 'ё', 'и', 'й', 'i', 'ы', 'э', 'ю', 'я',
            'ѣ', 'Ѣ', 'ѵ', 'Ѵ'
        };
        private string CheckSpecificRules(string substitue, char nextSourceChar)
        {
            if (substitue.Length == 2)
            {
                // Ц	cz, c	cz, c	cz, c	cz, c	cz, c	рекомендуется использовать С перед буквами I, Е, Y, J; в остальных случаях CZ
                if ((substitue[1] == 'z') && (RuleCzCheck.Contains(nextSourceChar)))
                {
                    return substitue.Substring(0, 1);
                }
            }
            return substitue;
        }
    }
}
