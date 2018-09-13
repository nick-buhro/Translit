using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace NickBuhro.Translit.Tests.Assets
{
    internal static class AssetLoader
    {
        public static IEnumerable<object[]> Load(string regex, Func<Language, string, string, IEnumerable<object[]>> parser)
        {
            var prefix = typeof(AssetLoader).Namespace + ".";

            var languages = string.Join("|", Enum.GetNames(typeof(Language)));
            var rxLanguage = new Regex(
                $"^({languages})\\.(.*)$",
                RegexOptions.Compiled | RegexOptions.CultureInvariant);

            var rxName = new Regex(regex, RegexOptions.Compiled | RegexOptions.CultureInvariant);
                        
            var assembly = typeof(AssetLoader).Assembly;            
            foreach (var resourceName in assembly.GetManifestResourceNames())
            {
                if (!resourceName.StartsWith(prefix))
                    continue;

                var match = rxLanguage.Match(resourceName.Substring(prefix.Length));
                if (!match.Success) continue;

                if (!rxName.IsMatch(match.Groups[2].Value))
                    continue;

                var lang = (Language)Enum.Parse(typeof(Language), match.Groups[1].Value);

                using (var stream = assembly.GetManifestResourceStream(resourceName))
                using (var sr = new StreamReader(stream))
                {
                    var content = sr.ReadToEnd();
                    foreach (var testcase in parser(lang, match.Groups[2].Value, content))
                    {
                        yield return testcase;
                    }
                }
            }
        }
    }
}
