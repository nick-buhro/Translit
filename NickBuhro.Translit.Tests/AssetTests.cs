using NickBuhro.Translit.Tests.Assets;
using Xunit;

namespace NickBuhro.Translit.Tests
{
    public sealed class AssetTests
    {
        [Theory]
        [ClassData(typeof(FullAssets))]
        public void CyrillicToLatinTest(Language lang, string reference, string cyrillic, string latin)
        {
            var actual = Transliteration.CyrillicToLatin(cyrillic, lang);
            Assert.Equal(latin, actual);
        }

        [Theory]
        [ClassData(typeof(FullAssets))]
        public void LatinToCyrillicTest(Language lang, string reference, string cyrillic, string latin)
        {
            var actual = Transliteration.LatinToCyrillic(latin, lang);
            Assert.Equal(cyrillic, actual);
        }

        [Theory]
        [ClassData(typeof(RoundAssets))]
        public void RoundTest(Language lang, string reference, string text)
        {
            var latin = Transliteration.CyrillicToLatin(text, lang);
            var actual = Transliteration.LatinToCyrillic(latin, lang);
            Assert.Equal(text, actual);
        }
    }
}
