using System.Collections.Generic;

namespace NickBuhro.Translit.Sandbox.v2
{
    internal sealed class Rules
    {
        private const string _crules = "IEYJ";
        private readonly Dictionary<string, Dictionary<Language, string>> _data;
        
        public Rules()
        {
            _data = new Dictionary<string, Dictionary<Language, string>>()
            {
                { "а", new Dictionary<Language, string>() { {Language.Russian, "a" }, {Language.Belorussian, "a" }, {Language.Ukrainian, "a" }, {Language.Bulgarian, "a" }, {Language.Macedonian, "a" } } },
                { "б", new Dictionary<Language, string>() { {Language.Russian, "b" }, {Language.Belorussian, "b" }, {Language.Ukrainian, "b" }, {Language.Bulgarian, "b" }, {Language.Macedonian, "b" } } },
                { "в", new Dictionary<Language, string>() { {Language.Russian, "v" }, {Language.Belorussian, "v" }, {Language.Ukrainian, "v" }, {Language.Bulgarian, "v" }, {Language.Macedonian, "v" } } },
                { "г", new Dictionary<Language, string>() { {Language.Russian, "g" }, {Language.Belorussian, "h" }, {Language.Ukrainian, "h" }, {Language.Bulgarian, "g" }, {Language.Macedonian, "g" } } },
                { "ѓ", new Dictionary<Language, string>() { {Language.Russian, null }, {Language.Belorussian, null }, {Language.Ukrainian, null }, {Language.Bulgarian, null }, {Language.Macedonian, "g`" } } },
                { "ґ", new Dictionary<Language, string>() { {Language.Russian, null }, {Language.Belorussian, null }, {Language.Ukrainian, "g`" }, {Language.Bulgarian, null }, {Language.Macedonian, null } } },
                { "д", new Dictionary<Language, string>() { {Language.Russian, "d" }, {Language.Belorussian, "d" }, {Language.Ukrainian, "d" }, {Language.Bulgarian, "d" }, {Language.Macedonian, "d" } } },
                { "е", new Dictionary<Language, string>() { {Language.Russian, "e" }, {Language.Belorussian, "e" }, {Language.Ukrainian, "e" }, {Language.Bulgarian, "e" }, {Language.Macedonian, "e" } } },
                { "ё", new Dictionary<Language, string>() { {Language.Russian, "yo" }, {Language.Belorussian, "yo" }, {Language.Ukrainian, null }, {Language.Bulgarian, null }, {Language.Macedonian, null } } },
                { "є", new Dictionary<Language, string>() { {Language.Russian, null }, {Language.Belorussian, null }, {Language.Ukrainian, "ye" }, {Language.Bulgarian, null }, {Language.Macedonian, null } } },
                { "ж", new Dictionary<Language, string>() { {Language.Russian, "zh" }, {Language.Belorussian, "zh" }, {Language.Ukrainian, "zh" }, {Language.Bulgarian, "zh" }, {Language.Macedonian, "zh" } } },
                { "з", new Dictionary<Language, string>() { {Language.Russian, "z" }, {Language.Belorussian, "z" }, {Language.Ukrainian, "z" }, {Language.Bulgarian, "z" }, {Language.Macedonian, "z" } } },
                { "s", new Dictionary<Language, string>() { {Language.Russian, null }, {Language.Belorussian, null }, {Language.Ukrainian, null }, {Language.Bulgarian, null }, {Language.Macedonian, "z`" } } },
                { "и", new Dictionary<Language, string>() { {Language.Russian, "i" }, {Language.Belorussian, null }, {Language.Ukrainian, "y`" }, {Language.Bulgarian, "i" }, {Language.Macedonian, "i" } } },
                { "й", new Dictionary<Language, string>() { {Language.Russian, "j" }, {Language.Belorussian, "j" }, {Language.Ukrainian, "j" }, {Language.Bulgarian, "j" }, {Language.Macedonian, null } } },
                { "j", new Dictionary<Language, string>() { {Language.Russian, null }, {Language.Belorussian, null }, {Language.Ukrainian, null }, {Language.Bulgarian, null }, {Language.Macedonian, "j" } } },
                { "i", new Dictionary<Language, string>() { {Language.Russian, "i" }, {Language.Belorussian, "i" }, {Language.Ukrainian, "i" }, {Language.Bulgarian, "i" }, {Language.Macedonian, null } } },
                { "ї", new Dictionary<Language, string>() { {Language.Russian, null }, {Language.Belorussian, null }, {Language.Ukrainian, "yi" }, {Language.Bulgarian, null }, {Language.Macedonian, null } } },
                { "к", new Dictionary<Language, string>() { {Language.Russian, "k" }, {Language.Belorussian, "k" }, {Language.Ukrainian, "k" }, {Language.Bulgarian, "k" }, {Language.Macedonian, "k" } } },
                { "ќ", new Dictionary<Language, string>() { {Language.Russian, null }, {Language.Belorussian, null }, {Language.Ukrainian, null }, {Language.Bulgarian, null }, {Language.Macedonian, "k`" } } },
                { "л", new Dictionary<Language, string>() { {Language.Russian, "l" }, {Language.Belorussian, "l" }, {Language.Ukrainian, "l" }, {Language.Bulgarian, "l" }, {Language.Macedonian, "l" } } },
                { "љ", new Dictionary<Language, string>() { {Language.Russian, null }, {Language.Belorussian, null }, {Language.Ukrainian, null }, {Language.Bulgarian, null }, {Language.Macedonian, "l`" } } },
                { "м", new Dictionary<Language, string>() { {Language.Russian, "m" }, {Language.Belorussian, "m" }, {Language.Ukrainian, "m" }, {Language.Bulgarian, "m" }, {Language.Macedonian, "m" } } },
                { "н", new Dictionary<Language, string>() { {Language.Russian, "n" }, {Language.Belorussian, "n" }, {Language.Ukrainian, "n" }, {Language.Bulgarian, "n" }, {Language.Macedonian, "п" } } },
                { "њ", new Dictionary<Language, string>() { {Language.Russian, null }, {Language.Belorussian, null }, {Language.Ukrainian, null }, {Language.Bulgarian, null }, {Language.Macedonian, "n`" } } },
                { "о", new Dictionary<Language, string>() { {Language.Russian, "o" }, {Language.Belorussian, "o" }, {Language.Ukrainian, "o" }, {Language.Bulgarian, "o" }, {Language.Macedonian, "o" } } },
                { "п", new Dictionary<Language, string>() { {Language.Russian, "p" }, {Language.Belorussian, "p" }, {Language.Ukrainian, "p" }, {Language.Bulgarian, "p" }, {Language.Macedonian, "p" } } },
                { "р", new Dictionary<Language, string>() { {Language.Russian, "r" }, {Language.Belorussian, "r" }, {Language.Ukrainian, "r" }, {Language.Bulgarian, "r" }, {Language.Macedonian, "r" } } },
                { "с", new Dictionary<Language, string>() { {Language.Russian, "s" }, {Language.Belorussian, "s" }, {Language.Ukrainian, "s" }, {Language.Bulgarian, "s" }, {Language.Macedonian, "s" } } },
                { "т", new Dictionary<Language, string>() { {Language.Russian, "t" }, {Language.Belorussian, "t" }, {Language.Ukrainian, "t" }, {Language.Bulgarian, "t" }, {Language.Macedonian, "t" } } },
                { "у", new Dictionary<Language, string>() { {Language.Russian, "u" }, {Language.Belorussian, "u" }, {Language.Ukrainian, "u" }, {Language.Bulgarian, "u" }, {Language.Macedonian, "u" } } },
                { "ў", new Dictionary<Language, string>() { {Language.Russian, null }, {Language.Belorussian, "u`" }, {Language.Ukrainian, null }, {Language.Bulgarian, null }, {Language.Macedonian, null } } },
                { "ф", new Dictionary<Language, string>() { {Language.Russian, "f" }, {Language.Belorussian, "f" }, {Language.Ukrainian, "f" }, {Language.Bulgarian, "f" }, {Language.Macedonian, "f" } } },
                { "х", new Dictionary<Language, string>() { {Language.Russian, "x" }, {Language.Belorussian, "x" }, {Language.Ukrainian, "x" }, {Language.Bulgarian, "x" }, {Language.Macedonian, "x" } } },
                { "ц", new Dictionary<Language, string>() { {Language.Russian, "cz" }, {Language.Belorussian, "cz" }, {Language.Ukrainian, "cz" }, {Language.Bulgarian, "cz" }, {Language.Macedonian, "cz" } } },
                { "ч", new Dictionary<Language, string>() { {Language.Russian, "ch" }, {Language.Belorussian, "ch" }, {Language.Ukrainian, "ch" }, {Language.Bulgarian, "ch" }, {Language.Macedonian, "ch" } } },
                { "џ", new Dictionary<Language, string>() { {Language.Russian, null }, {Language.Belorussian, null }, {Language.Ukrainian, null }, {Language.Bulgarian, null }, {Language.Macedonian, "dh" } } },
                { "ш", new Dictionary<Language, string>() { {Language.Russian, "sh" }, {Language.Belorussian, "sh" }, {Language.Ukrainian, "sh" }, {Language.Bulgarian, "sh" }, {Language.Macedonian, "sh" } } },
                { "щ", new Dictionary<Language, string>() { {Language.Russian, "shh" }, {Language.Belorussian, null }, {Language.Ukrainian, "shh" }, {Language.Bulgarian, "sht" }, {Language.Macedonian, null } } },
                { "ъ", new Dictionary<Language, string>() { {Language.Russian, "``" }, {Language.Belorussian, null }, {Language.Ukrainian, null }, {Language.Bulgarian, "a`" }, {Language.Macedonian, null } } },
                { "ы", new Dictionary<Language, string>() { {Language.Russian, "y`" }, {Language.Belorussian, "y`" }, {Language.Ukrainian, null }, {Language.Bulgarian, null }, {Language.Macedonian, null } } },
                { "ь", new Dictionary<Language, string>() { {Language.Russian, "`" }, {Language.Belorussian, "`" }, {Language.Ukrainian, "`" }, {Language.Bulgarian, "`" }, {Language.Macedonian, null } } },
                { "э", new Dictionary<Language, string>() { {Language.Russian, "e`" }, {Language.Belorussian, "e`" }, {Language.Ukrainian, null }, {Language.Bulgarian, null }, {Language.Macedonian, null } } },
                { "ю", new Dictionary<Language, string>() { {Language.Russian, "yu" }, {Language.Belorussian, "yu" }, {Language.Ukrainian, "yu" }, {Language.Bulgarian, "yu" }, {Language.Macedonian, null } } },
                { "я", new Dictionary<Language, string>() { {Language.Russian, "ya" }, {Language.Belorussian, "ya" }, {Language.Ukrainian, "ya" }, {Language.Bulgarian, "ya" }, {Language.Macedonian, null } } },
                { "’", new Dictionary<Language, string>() { {Language.Russian, "'" }, {Language.Belorussian, "'" }, {Language.Ukrainian, "'" }, {Language.Bulgarian, "'" }, {Language.Macedonian, "'" } } },
                { "ѣ", new Dictionary<Language, string>() { {Language.Russian, "ye" }, {Language.Belorussian, null }, {Language.Ukrainian, null }, {Language.Bulgarian, "ye" }, {Language.Macedonian, null } } },
                { "ѳ", new Dictionary<Language, string>() { {Language.Russian, "fh" }, {Language.Belorussian, null }, {Language.Ukrainian, null }, {Language.Bulgarian, "fh" }, {Language.Macedonian, null } } },
                { "ѵ", new Dictionary<Language, string>() { {Language.Russian, "yh" }, {Language.Belorussian, null }, {Language.Ukrainian, null }, {Language.Bulgarian, "yh" }, {Language.Macedonian, null } } },
                { "ѫ", new Dictionary<Language, string>() { {Language.Russian, null }, {Language.Belorussian, null }, {Language.Ukrainian, null }, {Language.Bulgarian, "о`" }, {Language.Macedonian, null } } },
                { "№", new Dictionary<Language, string>() { {Language.Russian, "#" }, {Language.Belorussian, "#" }, {Language.Ukrainian, "#" }, {Language.Bulgarian, "#" }, {Language.Macedonian, "#" } } }
            };
        }

        public Dictionary<string, string> CreateCyrillicToLatinDictionary(Language lang)
        {
            var result = new Dictionary<string, string>();

            foreach (var p in _data)
            {
                var loCyrillic = p.Key;
                var loLatin = p.Value[lang];

                if (loLatin == null) continue;

                var upCyrillic = loCyrillic.ToUpper();
                var upLatin = char.ToUpper(loLatin[0]) + loLatin.Substring(1);

                result.Add(loCyrillic, loLatin);
                if (loCyrillic != upCyrillic)
                {
                    result.Add(upCyrillic, upLatin);
                    if (_crules.IndexOf(upLatin[0]) >= 0)
                    {
                        result["ц" + loCyrillic] = "c" + loLatin;
                        result["Ц" + loCyrillic] = "C" + loLatin;
                        result["ц" + upCyrillic] = "c" + upLatin;
                        result["Ц" + upCyrillic] = "C" + upLatin;
                    }
                }                
            }

            return result;
        }

        public Dictionary<string, string> CreateLatinToCyrillicDictionary(Language lang)
        {
            var result = new Dictionary<string, string>();

            foreach (var p in _data)
            {
                var loCyrillic = p.Key;
                var loLatin = p.Value[lang];

                if (loLatin == null) continue;
                
                var upCyrillic = loCyrillic.ToUpper();
                var upLatin = char.ToUpper(loLatin[0]) + loLatin.Substring(1);

                if (!result.ContainsKey(loLatin))
                {
                    result.Add(loLatin, loCyrillic);
                    if (!result.ContainsKey(upLatin))
                    {
                        result.Add(upLatin, upCyrillic);
                    }
                }
            }

            result.Add("c", "ц");
            result.Add("C", "Ц");

            return result;
        }
    }
}
