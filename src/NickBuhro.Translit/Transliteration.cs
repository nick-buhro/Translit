using System;

namespace NickBuhro
{
    /// <summary>
    ///  Cyrillic-latin transliteration (support only slavik languages) by GOST 7.79-2000 (ISO 9).
    /// </summary>
    public static class Transliteration
    {
        /// <summary>
        /// Slavik language with cyrillic alphabet.
        /// </summary>
        public enum Language
        {
            /// <summary>
            /// Unknown language. Most common rules will be used for transliteration.
            /// </summary>
            Unknown,

            /// <summary>
            /// Russain language.
            /// </summary>
            Russian,

            /// <summary>
            /// Belorussian language.
            /// </summary>
            Belorussian,

            /// <summary>
            /// Ukranian language.
            /// </summary>
            Ukrainian,

            /// <summary>
            /// Bulgarian language.
            /// </summary>
            Bulgarian,

            /// <summary>
            /// Macedonian language.
            /// </summary>
            Macedonian
        }

        /// <summary>
        /// Transliterate cyrillyc string to latin.
        /// </summary>
        /// <param name="cyrillicSource">Source string.</param>
        /// <param name="language">Specify it to determine correct transliteration rules 
        /// (it can be a little bit defferent for languages).</param>
        /// <returns>Transliterated string.</returns>
        public static string CyrillicToLatin(string cyrillicSource, Language language = Language.Unknown)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Transliterate latin string to cyrillyc.
        /// </summary>
        /// <param name="latinSource">Source string.</param>
        /// <param name="language">Specify it to determine correct transliteration rules 
        /// (it can be a little bit defferent for languages).</param>
        /// <returns>Transliterated string.</param>
        /// <returns>Cyrillyc string.</returns>
        public static string LatinToCyrillyc(string latinSource, Language language = Language.Unknown)
        {
            throw new NotImplementedException();
        }
    }
}
