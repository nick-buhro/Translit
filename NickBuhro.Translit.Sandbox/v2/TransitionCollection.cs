using System.Collections.Generic;

namespace NickBuhro.Translit.Sandbox.v2
{
    internal sealed class TransitionCollection: Dictionary<char, Output>
    {
        public string DefaultOutputText { get; set; }
    }
}
