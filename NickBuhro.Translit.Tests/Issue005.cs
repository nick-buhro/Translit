using Xunit;

namespace NickBuhro.Translit.Tests
{
    /// <summary>
    /// Tests for <see href="https://github.com/nick-buhro/Translit/issues/5">GitHub Issue #5</see>.
    /// </summary>
    public sealed class Issue005
    {
        [Fact]
        public void TestRu()
        {
            var actual = Transliteration.CyrillicToLatin("Obstacles", Language.Russian);
            Assert.Equal("Obstacles", actual);
        }

        [Fact]
        public void TestMk()
        {
            var actual = Transliteration.CyrillicToLatin("Obstacles", Language.Macedonian);
            Assert.Equal("Obz`taclez`", actual);
        }
    }
}
