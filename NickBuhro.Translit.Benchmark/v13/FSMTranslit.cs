using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("NickBuhro.Translit.Benchmark")]

namespace NickBuhro.Translit.Benchmark.v13
{
    internal static class FSMTranslit
    {
        private static readonly Dictionary<Language, (string stateName, string fallbackText, Dictionary<char, (int state, string text)> transitions)[]> _c2l;
        private static readonly Dictionary<Language, (string stateName, string fallbackText, Dictionary<char, (int state, string text)> transitions)[]> _l2c;
        
        static FSMTranslit()
        {
            var rules = new Rules();
            _c2l = new Dictionary<Language, (string stateName, string fallbackText, Dictionary<char, (int state, string text)> transitions)[]>
            {
                { Language.Russian, BuildFSM(rules.CreateCyrillicToLatinDictionary(Language.Russian)) },
                { Language.Belorussian, BuildFSM(rules.CreateCyrillicToLatinDictionary(Language.Belorussian)) },
                { Language.Ukrainian, BuildFSM(rules.CreateCyrillicToLatinDictionary(Language.Ukrainian)) },
                { Language.Bulgarian, BuildFSM(rules.CreateCyrillicToLatinDictionary(Language.Bulgarian)) },
                { Language.Macedonian, BuildFSM(rules.CreateCyrillicToLatinDictionary(Language.Macedonian)) },
            };
            _l2c = new Dictionary<Language, (string stateName, string fallbackText, Dictionary<char, (int state, string text)> transitions)[]>
            {
                { Language.Russian, BuildFSM(rules.CreateLatinToCyrillicDictionary(Language.Russian)) },
                { Language.Belorussian, BuildFSM(rules.CreateLatinToCyrillicDictionary(Language.Belorussian)) },
                { Language.Ukrainian, BuildFSM(rules.CreateLatinToCyrillicDictionary(Language.Ukrainian)) },
                { Language.Bulgarian, BuildFSM(rules.CreateLatinToCyrillicDictionary(Language.Bulgarian)) },
                { Language.Macedonian, BuildFSM(rules.CreateLatinToCyrillicDictionary(Language.Macedonian)) },
            };
        }        
        
        public static string CyrillicToLatin(string text, Language language)
        {
            var fsm = _c2l[language];
            return Convert(text, fsm);
        }

        public static string LatinToCyrillic(string text, Language language)
        {
            var fsm = _l2c[language];
            return Convert(text, fsm);
        }

        internal static string Convert(string text, (string stateName, string fallbackText, Dictionary<char, (int state, string text)> transitions)[] fsm)
        {
            var sb = new StringBuilder(text.Length);
            
            var state = 0;
            for (var i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var tc = fsm[state];
                if (tc.transitions.TryGetValue(c, out (int state, string text) output))
                {
                    state = output.state;
                    sb.Append(output.text);
                }
                else
                {
                    state = 0;
                    sb.Append(tc.fallbackText);
                    sb.Append(c);
                }
            }

            {
                var tc = fsm[state];
                sb.Append(tc.fallbackText);
            }

            return sb.ToString();
        }



        internal static (string stateName, string fallbackText, Dictionary<char, (int state, string text)> transitions)[] BuildFSM(Dictionary<string, string> replacements)
        {
            // Find all states

            var result = GetStates(replacements)
                .OrderBy(s => s.Length)
                .ThenBy(s => s)
                .Select(s => (stateName: s, fallbackText: "", transitions: new Dictionary<char, (int state, string text)>()))
                .ToArray();

            var stateLookup = new Dictionary<string, int>(result.Length);
            for (var i = 0; i < result.Length; i++)
            {
                stateLookup.Add(result[i].stateName, i);
            }
                        
            // Generate simple transitions without output

            foreach (var k in replacements.Keys)
            {
                for (var i = 1; i < k.Length; i++)
                {
                    var state = stateLookup[k.Substring(0, i - 1)];
                    var input = k[i - 1];
                    var output = (stateLookup[k.Substring(0, i)], "");
                    if (!result[state].transitions.ContainsKey(input))
                    {
                        result[state].transitions.Add(input, output);
                    }
                }
            }

            // Generate transitions for completed replacements

            foreach (var p in replacements)
            {
                var state = stateLookup[p.Key.Substring(0, p.Key.Length - 1)];
                var input = p.Key[p.Key.Length - 1];
                var output = (0, p.Value);
                if (!result[state].transitions.ContainsKey(input))
                {
                    result[state].transitions.Add(input, output);
                }
            }

            // Generate transitions to go back

            for (var state = 1; state < result.Length; state++)
            {
                var tail = result[state].stateName;
                var outputText = "";
                for (; ; )
                {
                    string replSource = tail[0].ToString();
                    string replTarget = replSource;
                    {
                        var s = tail;
                        while (s.Length > 0)
                        {
                            if (replacements.TryGetValue(s, out string value))
                            {
                                replSource = s;
                                replTarget = value;
                                break;
                            }
                            s = s.Substring(0, s.Length - 1);
                        }
                    }

                    outputText += replTarget;
                    tail = tail.Substring(replSource.Length);
                    
                    if (stateLookup.TryGetValue(tail, out int outputState))
                    {
                        foreach (var t in result[outputState].transitions)
                        {
                            if (!result[state].transitions.ContainsKey(t.Key))
                            {                                
                                var output = (t.Value.state, outputText + t.Value.text);
                                result[state].transitions.Add(t.Key, output);
                            }
                        }
                        result[state].fallbackText = outputText;
                        break;
                    }                    
                }
            }

            //

            return result;
        }        

        private static IEnumerable<string> GetStates(Dictionary<string, string> replacements)
        {
            var result = new HashSet<string> { "" };
            foreach (var k in replacements.Keys)
            {
                for (var i = 1; i < k.Length; i++)
                {
                    result.Add(k.Substring(0, i));
                }
            }
            return result;
        }
    }
}
