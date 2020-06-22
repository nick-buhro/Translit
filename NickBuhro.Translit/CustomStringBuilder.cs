using System;
#if NET45 || NETSTANDARD1_3
using System.Buffers;
#endif

namespace NickBuhro.Translit
{
    internal struct CustomStringBuilder : IDisposable
    {
        private readonly char[] _array;
        private int _index;

        public CustomStringBuilder(int capacity)
        {
#if NET45 || NETSTANDARD1_3
            _array = ArrayPool<char>.Shared.Rent(capacity);
#else
            _array = new char[capacity];
#endif
            _index = 0;
        }

        public void Append(char c)
        {
            _array[_index++] = c;
        }

        public override string ToString()
        {
            return new string(_array, 0, _index);
        }

        public void Dispose()
        {
#if NET45 || NETSTANDARD1_3
            ArrayPool<char>.Shared.Return(_array);
#endif
        }
    }
}
