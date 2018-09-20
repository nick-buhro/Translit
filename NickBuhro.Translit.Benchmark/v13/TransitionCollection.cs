using System.Collections.Generic;

namespace NickBuhro.Translit.Benchmark.v13
{
    internal sealed class TransitionCollection: Dictionary<char, Output>
    {
        public string DefaultOutputText { get; set; }
    }
}
