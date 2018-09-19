using Xunit;

namespace NickBuhro.Translit.Tests
{
    public sealed class GeneralTests
    {
        [Fact]
        public void C2LNullTest()
        {
            var result = Transliteration.CyrillicToLatin(null);
            Assert.Null(result);
        }

        [Fact]
        public void L2CNullTest()
        {
            var result = Transliteration.LatinToCyrillic(null);
            Assert.Null(result);
        }

        [Fact]
        public void C2LEmptyTest()
        {
            var result = Transliteration.CyrillicToLatin("");
            Assert.Equal("", result);
        }

        [Fact]
        public void L2CEmptyTest()
        {
            var result = Transliteration.LatinToCyrillic("");
            Assert.Equal("", result);
        }
    }
}
