using System;
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

        [Fact]
        public void C2LSimpleTest()
        {
            var result = Transliteration.CyrillicToLatin("Абв");
            Assert.Equal("Abv", result);
        }

        [Fact]
        public void L2CSimpleTest()
        {
            var result = Transliteration.LatinToCyrillic("Abv");
            Assert.Equal("Абв", result);
        }

        [Fact]
        public void C2LNumTest()
        {
            var result = Transliteration.CyrillicToLatin("123");
            Assert.Equal("123", result);
        }

        [Fact]
        public void L2CNumTest()
        {
            var result = Transliteration.LatinToCyrillic("123");
            Assert.Equal("123", result);
        }

        [Fact]
        public void C2LInvalidLanguageTest()
        {
            var lang = default(Language) - 1;
            Assert.Throws<NotSupportedException>(() => Transliteration.CyrillicToLatin("123", lang));
        }

        [Fact]
        public void L2CInvalidLanguageTest()
        {
            var lang = default(Language) - 1;
            Assert.Throws<NotSupportedException>(() => Transliteration.LatinToCyrillic("123", lang));
        }
    }
}
