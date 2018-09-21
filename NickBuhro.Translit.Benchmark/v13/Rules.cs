using System.Collections.Generic;

namespace NickBuhro.Translit.Benchmark.v13
{
    internal sealed class Rules
    {
        private const string _crules = "IEYJ";

        private readonly Dictionary<Language, int> _langIndex = new Dictionary<Language, int>
        {
            { Language.Russian, 0 },
            { Language.Belorussian, 1 },
            { Language.Ukrainian, 2 },
            { Language.Bulgarian, 3 },
            { Language.Macedonian, 4 },
        };

        private readonly Dictionary<string, string[]> _data = new Dictionary<string, string[]>()
        {
            { "а", new [] { "a", "a", "a", "a", "a" } },
            { "б", new [] { "b", "b", "b", "b", "b" } },
            { "в", new [] { "v", "v", "v", "v", "v" } },
            { "г", new [] { "g", "h", "h", "g", "g" } },
            { "ѓ", new [] { null, null, null, null, "g`" } },
            { "ґ", new [] { null, null, "g`", null, null } },
            { "д", new [] { "d", "d", "d", "d", "d" } },
            { "е", new [] { "e", "e", "e", "e", "e" } },
            { "ё", new [] { "yo", "yo", null, null, null } },
            { "є", new [] { null, null, "ye", null, null } },
            { "ж", new [] { "zh", "zh", "zh", "zh", "zh" } },
            { "з", new [] { "z", "z", "z", "z", "z" } },
            { "s", new [] { null, null, null, null, "z`" } },
            { "и", new [] { "i", null, "y`", "i", "i" } },
            { "й", new [] { "j", "j", "j", "j", null } },
            { "j", new [] { null, null, null, null, "j" } },
            { "i", new [] { "i", "i", "i", "i", null } },
            { "ї", new [] { null, null, "yi", null, null } },
            { "к", new [] { "k", "k", "k", "k", "k" } },
            { "ќ", new [] { null, null, null, null, "k`" } },
            { "л", new [] { "l", "l", "l", "l", "l" } },
            { "љ", new [] { null, null, null, null, "l`" } },
            { "м", new [] { "m", "m", "m", "m", "m" } },
            { "н", new [] { "n", "n", "n", "n", "п" } },
            { "њ", new [] { null, null, null, null, "n`" } },
            { "о", new [] { "o", "o", "o", "o", "o" } },
            { "п", new [] { "p", "p", "p", "p", "p" } },
            { "р", new [] { "r", "r", "r", "r", "r" } },
            { "с", new [] { "s", "s", "s", "s", "s" } },
            { "т", new [] { "t", "t", "t", "t", "t" } },
            { "у", new [] { "u", "u", "u", "u", "u" } },
            { "ў", new [] { null, "u`", null, null, null } },
            { "ф", new [] { "f", "f", "f", "f", "f" } },
            { "х", new [] { "x", "x", "x", "x", "x" } },
            { "ц", new [] { "cz", "cz", "cz", "cz", "cz" } },
            { "ч", new [] { "ch", "ch", "ch", "ch", "ch" } },
            { "џ", new [] { null, null, null, null, "dh" } },
            { "ш", new [] { "sh", "sh", "sh", "sh", "sh" } },
            { "щ", new [] { "shh", null, "shh", "sht", null } },
            { "ъ", new [] { "``", null, null, "a`", null } },
            { "ы", new [] { "y`", "y`", null, null, null } },
            { "ь", new [] { "`", "`", "`", "`", null } },
            { "э", new [] { "e`", "e`", null, null, null } },
            { "ю", new [] { "yu", "yu", "yu", "yu", null } },
            { "я", new [] { "ya", "ya", "ya", "ya", null } },
            { "’", new [] { "'", "'", "'", "'", "'" } },
            { "ѣ", new [] { "ye", null, null, "ye", null } },
            { "ѳ", new [] { "fh", null, null, "fh", null } },
            { "ѵ", new [] { "yh", null, null, "yh", null } },
            { "ѫ", new [] { null, null, null, "о`", null } },
            { "№", new [] { "#", "#", "#", "#", "#" } }
        };


        public Dictionary<string, string> CreateCyrillicToLatinDictionary(Language lang)
        {
            var result = new Dictionary<string, string>();

            foreach (var p in _data)
            {
                var loCyrillic = p.Key;
                var loLatin = p.Value[_langIndex[lang]];

                if (loLatin == null) continue;
                if ((loCyrillic == loLatin) && (loCyrillic.Length == 1))
                    continue;

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
                var loLatin = p.Value[_langIndex[lang]];

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
