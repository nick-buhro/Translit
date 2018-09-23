using NickBuhro.Translit.Tests.Assets;
using Xunit;

namespace NickBuhro.Translit.Tests
{
    public sealed class AssetTests
    {
        [Theory]
        [ClassData(typeof(AssetCollectionAlphabetC2L))]
        public void AlphabetC2LTest(Language lang, string reference, string cyrillic, string latin)
        {
            var actual = Transliteration.CyrillicToLatin(cyrillic, lang);
            Assert.Equal(latin, actual);
        }

        [Theory]
        [ClassData(typeof(AssetCollectionAlphabetL2C))]
        public void AlphabetL2CTest(Language lang, string reference, string cyrillic, string latin)
        {
            var actual = Transliteration.LatinToCyrillic(latin, lang);
            Assert.Equal(cyrillic, actual);
        }


        [Theory]
        [ClassData(typeof(AssetCollectionExact))]
        public void ExactC2LTest(Language lang, string reference, string cyrillic, string latin)
        {
            var actual = Transliteration.CyrillicToLatin(cyrillic, lang);
            Assert.Equal(latin, actual);
        }

        [Theory]
        [ClassData(typeof(AssetCollectionExact))]
        public void ExactL2CTest(Language lang, string reference, string cyrillic, string latin)
        {
            var actual = Transliteration.LatinToCyrillic(latin, lang);
            Assert.Equal(cyrillic, actual);
        }

        [Theory]
        [ClassData(typeof(AssetCollectionRound))]
        public void RoundTest(Language lang, string reference, string text)
        {
            var latin = Transliteration.CyrillicToLatin(text, lang);
            var actual = Transliteration.LatinToCyrillic(latin, lang);
            Assert.Equal(text, actual);
        }
    }
}
