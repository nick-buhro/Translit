using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NickBuhro.Translit.Tests.Assets
{
    public sealed class AssetCollectionRound : AssetCollection
    {
        public AssetCollectionRound()
        {
            var langPattern = string.Join("|", LanguageMonikers.Keys);
            var regex = new Regex($"^Round\\.({langPattern})_.*\\.txt$", RegexOptions.CultureInvariant);
            foreach (var file in LoadResources(regex))
            {
                var lang = LanguageMonikers[file.Item1.Groups[1].Value];
                AddRange(ParseFile(lang, file.Item1.Value, file.Item2));
            }
        }

        private static IEnumerable<object[]> ParseFile(Language lang, string filename, string content)
        {
            yield return new object[]
            {
                lang,
                filename,
                content                
            };
        }
    }
}
