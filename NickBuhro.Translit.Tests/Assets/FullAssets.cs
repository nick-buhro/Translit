using System;
using System.Collections.Generic;
using System.Globalization;

namespace NickBuhro.Translit.Tests.Assets
{
    public sealed class FullAssets : List<object[]>
    {
        public FullAssets()
        {
            AddRange(AssetLoader.Load(@"^Full\d\d\.txt$", ParseFile));
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
