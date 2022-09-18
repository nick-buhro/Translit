using Xunit;

namespace NickBuhro.Translit.Tests
{
    /// <summary>
    /// Tests for <see href="https://github.com/nick-buhro/Translit/issues/5">GitHub Issue #5</see>.
    /// </summary>
    public sealed class Issue014
    {
        const string latIi = "Ii";  // 0x49 , 0x69
        const string ukrIi = "Іі";  // 0x406, 0x456

        [Fact]
        public void TestIiL2C()
        {
            var actual = Transliteration.LatinToCyrillic(latIi, Language.Ukrainian);
            Assert.Equal(ukrIi, actual);
        }

        [Fact]
        public void TestIiC2L()
        {
            var actual = Transliteration.CyrillicToLatin(ukrIi, Language.Ukrainian);
            Assert.Equal(latIi, actual);
        }
    }
}
