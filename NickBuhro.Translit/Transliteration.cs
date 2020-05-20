using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NickBuhro.Translit.Benchmark")]
[assembly: InternalsVisibleTo("NickBuhro.Translit.Tests")]

namespace NickBuhro.Translit
{
    /// <summary>
    ///  Cyrillic-latin transliteration (support only slavic languages) by GOST 7.79-2000 (ISO 9).
    /// </summary>
    public static partial class Transliteration
    {
        /// <summary>
        /// Transliterate cyrillic string to latin.
        /// </summary>
        /// <param name="cyrillicSource">Source string.</param>
        /// <param name="language">Specify it to determine correct transliteration rules 
        /// (it can be a little bit different for languages).</param>
        /// <returns>Transliterated string.</returns>
        public static string CyrillicToLatin(string cyrillicSource, Language language = Language.Unknown)
        {
            if (string.IsNullOrEmpty(cyrillicSource))
                return cyrillicSource;

            switch (language)
            {
                case Language.Unknown:
                case Language.Russian:
                    return CyrillicToLatinRussian(cyrillicSource);
                case Language.Belorussian:
                    return CyrillicToLatinBelorussian(cyrillicSource);
                case Language.Ukrainian:
                    return CyrillicToLatinUkrainian(cyrillicSource);
                case Language.Bulgarian:
                    return CyrillicToLatinBulgarian(cyrillicSource);
                case Language.Macedonian:
                    return CyrillicToLatinMacedonian(cyrillicSource);                    
            }

            throw new NotSupportedException();
        }

        /// <summary>
        /// Transliterate latin string to cyrillic.
        /// </summary>
        /// <param name="latinSource">Source string.</param>
        /// <param name="language">Specify it to determine correct transliteration rules 
        /// (it can be a little bit different for languages).</param>
        /// <returns>Cyrillic string.</returns>
        public static string LatinToCyrillic(string latinSource, Language language = Language.Unknown)
        {
            if (string.IsNullOrEmpty(latinSource))
                return latinSource;

            switch (language)
            {
                case Language.Unknown:
                case Language.Russian:
                    return LatinToCyrillicRussian(latinSource);
                case Language.Belorussian:
                    return LatinToCyrillicBelorussian(latinSource);
                case Language.Ukrainian:
                    return LatinToCyrillicUkrainian(latinSource);
                case Language.Bulgarian:
                    return LatinToCyrillicBulgarian(latinSource);
                case Language.Macedonian:
                    return LatinToCyrillicMacedonian(latinSource);
            }

            throw new NotSupportedException();
        }
    }
}
