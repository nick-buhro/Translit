using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace NickBuhro.Translit.Tests.Assets
{
    public abstract class AssetCollectionAlphabet : AssetCollection
    {
        public AssetCollectionAlphabet(bool c2l)
        {
            var content = LoadResources(new Regex("Alphabet.txt", RegexOptions.CultureInvariant))
                .First()
                .Item2;

            var strs = content.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            var header = ParseHeader(strs[0].Split('\t'));

            var emptyRules = new HashSet<Tuple<Language, string, int>>();
            var index = new HashSet<Tuple<Language, string>>();
            for (var i = 1; i < strs.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(strs[i]))
                    continue;

                var values = strs[i].Split('\t');
                var cyrillic = values[0];
                for (var j = 1; j < header.Length; j++)
                {
                    var lang = header[j];
                    var latin = values[j];
                    if (string.IsNullOrEmpty(latin))
                    {
                        emptyRules.Add(new Tuple<Language, string, int>(lang, cyrillic, i));
                        continue;
                    }                        

                    if (!index.Add(new Tuple<Language, string>(lang, c2l ? cyrillic : latin)))
                        continue;

                    var reference = " Ln:" + (i + 1).ToString("000", CultureInfo.InvariantCulture);
                    Add(new object[] {lang, reference, cyrillic, latin });
                }
            }

            foreach (var p in emptyRules)
            {
                if (index.Add(new Tuple<Language, string>(p.Item1, p.Item2)))
                {
                    var reference = " Ln:" + (p.Item3 + 1).ToString("000", CultureInfo.InvariantCulture);
                    Add(new object[] { p.Item1, reference, p.Item2, p.Item2 });
                }                
            }
        }

        private Language[] ParseHeader(string[] header)
        {
            var result = new Language[header.Length];
            for (var i = 1; i < result.Length; i++)
            {
                result[i] = LanguageMonikers[header[i]];
            }
            return result;
        }
    }


    public sealed class AssetCollectionAlphabetC2L : AssetCollectionAlphabet
    {
        public AssetCollectionAlphabetC2L()
            : base(true) { }
    }


    public sealed class AssetCollectionAlphabetL2C : AssetCollectionAlphabet
    {
        public AssetCollectionAlphabetL2C()
            : base(false) { }
    }

}
