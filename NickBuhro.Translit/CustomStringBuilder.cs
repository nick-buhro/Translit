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
#if NET45 || NETSTANDARD1_3
        private readonly bool _arrayPooling;
#endif

        public CustomStringBuilder(int capacity, bool? preferArrayPooling = null)
        {
#if NET45 || NETSTANDARD1_3            
            _arrayPooling = preferArrayPooling ?? capacity > 1000;
            _array = _arrayPooling
                ? ArrayPool<char>.Shared.Rent(capacity)
                : _array = new char[capacity];            
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
            if (_arrayPooling)
                ArrayPool<char>.Shared.Return(_array);
#endif
        }
    }
}
