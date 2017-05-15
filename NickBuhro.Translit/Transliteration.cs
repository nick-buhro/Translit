using System;
using NickBuhro.Translit.Implementation;

namespace NickBuhro.Translit
{
    /// <summary>
    ///  Cyrillic-latin transliteration (support only slavik languages) by GOST 7.79-2000 (ISO 9).
    /// </summary>
    public static class Transliteration
    {
        /// <summary>
        /// Transliterate cyrillyc string to latin.
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
        /// Transliterate latin string to cyrillyc.
        /// </summary>
        /// <param name="latinSource">Source string.</param>
        /// <param name="language">Specify it to determine correct transliteration rules 
        /// (it can be a little bit defferent for languages).</param>
        /// <returns>Cyrillyc string.</returns>
        public static string LatinToCyrillyc(string latinSource, Language language = Language.Unknown)
        {
            return new LatinToCyrillicConverter(latinSource, language)
                .Convert();
        }
    }
}
