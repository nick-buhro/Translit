using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NickBuhro.Translit.Benchmark")]

namespace NickBuhro.Translit.Sandbox.v2
{
    internal static class FSMTranslit
    {
        private static readonly Dictionary<Language, TransitionCollection[]> _c2l;
        private static readonly Dictionary<Language, TransitionCollection[]> _l2c;
        
        static FSMTranslit()
        {
            var rules = new Rules();
            _c2l = new Dictionary<Language, TransitionCollection[]>
            {
                { Language.Russian, BuildFSM(rules.CreateCyrillicToLatinDictionary(Language.Russian)) },
                { Language.Belorussian, BuildFSM(rules.CreateCyrillicToLatinDictionary(Language.Belorussian)) },
                { Language.Ukrainian, BuildFSM(rules.CreateCyrillicToLatinDictionary(Language.Ukrainian)) },
                { Language.Bulgarian, BuildFSM(rules.CreateCyrillicToLatinDictionary(Language.Bulgarian)) },
                { Language.Macedonian, BuildFSM(rules.CreateCyrillicToLatinDictionary(Language.Macedonian)) },
            };
            _l2c = new Dictionary<Language, TransitionCollection[]>
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
            return Convert(text, fsm, text.Length * 3);
        }

        public static string LatinToCyrillic(string text, Language language)
        {
            var fsm = _l2c[language];
            return Convert(text, fsm, text.Length);
        }

        internal static string Convert(string text, TransitionCollection[] fsm, int capacity)
        {
            var index = 0;
            var arr = new char[capacity];    
            
            var state = 0;
            for (var i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var tc = fsm[state];
                if (tc.TryGetValue(c, out Output output))
                {
                    state = output.State;
                    for (var j = 0; j < output.Text.Length; j++)
                    {
                        arr[index++] = output.Text[j];
                    }
                }
                else
                {
                    state = 0;
                    for (var j = 0; j < tc.DefaultOutputText.Length; j++)
                    {
                        arr[index++] = tc.DefaultOutputText[j];
                    }
                    arr[index++] = c;
                }
            }

            {
                var tc = fsm[state];
                for (var j = 0; j < tc.DefaultOutputText.Length; j++)
                {
                    arr[index++] = tc.DefaultOutputText[j];
                }
            }

            return new string(arr, 0, index);
        }

        internal static TransitionCollection[] BuildFSM(Dictionary<string, string> replacements)
        {
            // Find all states

            var stateNames = new List<string> { "" };
            foreach (var k in replacements.Keys)
            {
                for (var i = 1; i < k.Length; i++)
                {
                    var s = k.Substring(0, i);
                    if (!stateNames.Contains(s))
                        stateNames.Add(s);
                }
            }
            stateNames.Sort(new StateComparer());

            var stateLookup = new Dictionary<string, int>(stateNames.Count);
            for (var i = 0; i < stateNames.Count; i++)
            {
                stateLookup.Add(stateNames[i], i);
            }

            // Init result array

            var result = new TransitionCollection[stateLookup.Count];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = new TransitionCollection();
            }
            result[0].DefaultOutputText = "";
            
            // Generate simple transitions without output

            foreach (var k in replacements.Keys)
            {
                for (var i = 1; i < k.Length; i++)
                {
                    var state = stateLookup[k.Substring(0, i - 1)];
                    var input = k[i - 1];
                    var output = new Output(stateLookup[k.Substring(0, i)], "");
                    if (!result[state].ContainsKey(input))
                    {
                        result[state].Add(input, output);
                    }
                }
            }

            // Generate transitions for completed replacements

            foreach (var p in replacements)
            {
                var state = stateLookup[p.Key.Substring(0, p.Key.Length - 1)];
                var input = p.Key[p.Key.Length - 1];
                var output = new Output(0, p.Value);
                if (!result[state].ContainsKey(input))
                {
                    result[state].Add(input, output);
                }
            }

            // Generate transitions to go back

            for (var state = 1; state < result.Length; state++)
            {
                var tail = stateNames[state];
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
                        foreach (var t in result[outputState])
                        {
                            if (!result[state].ContainsKey(t.Key))
                            {
                                var output = new Output(t.Value.State, outputText + t.Value.Text);
                                result[state].Add(t.Key, output);
                            }
                        }
                        result[state].DefaultOutputText = outputText;
                        break;
                    }                    
                }
            }

            //

            return result;
        }        
    }
}
