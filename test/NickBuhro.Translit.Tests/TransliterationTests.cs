using Xunit;

namespace NickBuhro.Translit.Tests
{
    public sealed partial class TransliterationTests
    {
        private void RussianToLatinTestHelper(string source, string expectedResult)
        {
            var actual = Transliteration.CyrillicToLatin(source, Language.Russian);
            Assert.Equal(expectedResult, actual);
        }

        private void LatinToRussianTestHelper(string source, string expectedResult)
        {
            var actual = Transliteration.LatinToCyrillyc(source, Language.Russian);
            Assert.Equal(expectedResult, actual);
        }
    }
}
