using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NickBuhro.Translit.Implementation
{
    internal partial struct CyrillicToLatinConverter
    {
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

            foreach (var srcChar in _src)
            {
                string substitute;
                if (_ruleSet.TryGetValue(srcChar, out substitute))
                {
                    _sb.Append(substitute);
                }
                else
                {
                    _sb.Append(srcChar);
                }
            }

            return _sb.ToString();
        }
    }
}
