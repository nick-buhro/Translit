using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace NickBuhro.Translit.Tests.Assets
{
    public abstract class AssetCollection : List<object[]>
    {
        protected static readonly Dictionary<string, Language> LanguageMonikers = new Dictionary<string, Language>()
        {
            { "Be", Language.Belorussian },
            { "Bu", Language.Bulgarian },
            { "Ma", Language.Macedonian },
            { "Ru", Language.Russian },
            { "Uk", Language.Ukrainian },
        };            

        protected static IEnumerable<Tuple<Match, string>> LoadResources(Regex namePattern)
        {
            var assembly = typeof(AssetCollection).Assembly;
            var prefix = typeof(AssetCollection).Namespace + ".";
                        
            foreach (var fullName in assembly.GetManifestResourceNames())
            {
                if (!fullName.StartsWith(prefix))
                    continue;

                var name = fullName.Substring(prefix.Length);
                var match = namePattern.Match(name);
                if (!match.Success)
                    continue;

                string content;
                using (var stream = assembly.GetManifestResourceStream(fullName))
                using (var sr = new StreamReader(stream))
                {
                    content = sr.ReadToEnd();                    
                }

                yield return new Tuple<Match, string>(match, content);
            }
        }
    }
}
