using System.Collections.Generic;

namespace NickBuhro.Translit.Benchmark.v13
{
    internal sealed class StateComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var result = x.Length.CompareTo(y.Length);
            return (result != 0) ? result : x.CompareTo(y);
        }
    }
}
