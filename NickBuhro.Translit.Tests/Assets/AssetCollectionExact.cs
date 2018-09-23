using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace NickBuhro.Translit.Tests.Assets
{
    public sealed class AssetCollectionExact : AssetCollection
    {
        public AssetCollectionExact()
        {
            var langPattern = string.Join("|", LanguageMonikers.Keys);
            var regex = new Regex($"^Exact\\.({langPattern})_.*\\.txt$", RegexOptions.CultureInvariant);
            foreach (var file in LoadResources(regex))
            {
                var lang = LanguageMonikers[file.Item1.Groups[1].Value];
                AddRange(ParseFile(lang, file.Item1.Value, file.Item2));
            }
        }

        private static IEnumerable<object[]> ParseFile(Language lang, string filename, string content)
        {
            var lines = content.Split(new[] { Environment.NewLine, "\n" }, StringSplitOptions.None);
            for (var i = 0; i < (lines.Length - 1);)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    i++;
                    continue;
                }

                yield return CreateTestCase(
                    lang,
                    filename,
                    i + 1,
                    lines[i].Replace("@", "").Trim(),
                    lines[i + 1].Replace("@", "").Trim());

                i += 2;
            }
        }

        private static object[] CreateTestCase(Language lang, string fileName, int lineNumber, string cyrillic, string latin)
        {
            return new object[]
            {
                lang,
                fileName + " Ln:" + lineNumber.ToString("000", CultureInfo.InvariantCulture),
                cyrillic,
                latin                
            };
        }
    }
}
