using System.Collections.Generic;

namespace NickBuhro.Translit.Tests.Assets
{
    public sealed class RoundAssets : List<object[]>
    {
        public RoundAssets()
        {
            AddRange(AssetLoader.Load(@"^Round\d\d\.txt$", ParseFile));
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
