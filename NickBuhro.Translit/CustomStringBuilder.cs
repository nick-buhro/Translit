namespace NickBuhro.Translit
{
    internal struct CustomStringBuilder
    {
        private readonly char[] _array;
        private int _index;

        public CustomStringBuilder(int capacity)
        {
            _array = new char[capacity];
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
    }
}
