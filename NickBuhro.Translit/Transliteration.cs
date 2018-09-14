using System;
using System.Runtime.CompilerServices;
using NickBuhro.Translit.v1;

[assembly: InternalsVisibleTo("NickBuhro.Translit.Benchmark")]
[assembly: InternalsVisibleTo("NickBuhro.Translit.Tests")]

namespace NickBuhro.Translit
{
    /// <summary>
    ///  Cyrillic-latin transliteration (support only slavik languages) by GOST 7.79-2000 (ISO 9).
    /// </summary>
    public static class Transliteration
    {
        /// <summary>
        /// Transliterate cyrillic string to latin.
        /// </summary>
        /// <param name="cyrillicSource">Source string.</param>
        /// <param name="language">Specify it to determine correct transliteration rules 
        /// (it can be a little bit defferent for languages).</param>
        /// <returns>Transliterated string.</returns>
        public static string CyrillicToLatin(string cyrillicSource, Language language = Language.Unknown)
        {
            return new CyrillicToLatinConverter(cyrillicSource, language)
                .Convert();
        }

        /// <summary>
        /// Transliterate latin string to cyrillic.
        /// </summary>
        /// <param name="latinSource">Source string.</param>
        /// <param name="language">Specify it to determine correct transliteration rules 
        /// (it can be a little bit defferent for languages).</param>
        /// <returns>Cyrillic string.</returns>
        public static string LatinToCyrillic(string latinSource, Language language = Language.Unknown)
        {
            return new LatinToCyrillicConverter(latinSource, language)
                .Convert();
        }

        /// <summary>        
        /// The method is deprecated due to an error in the name.
        /// Use <see cref="LatinToCyrillic(string, Language)"/>.
        /// </summary>
        /// <param name="latinSource">Source string.</param>
        /// <param name="language">Specify it to determine correct transliteration rules 
        /// (it can be a little bit defferent for languages).</param>
        /// <returns>Cyrillic string.</returns>
        [Obsolete("The method is deprecated due to an error in the name.")]
        public static string LatinToCyrillyc(string latinSource, Language language = Language.Unknown)
        {
            return LatinToCyrillic(latinSource, language);
        }
    }
}
