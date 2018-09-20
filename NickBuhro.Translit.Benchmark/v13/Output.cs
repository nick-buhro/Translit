namespace NickBuhro.Translit.Benchmark.v13
{
    internal struct Output
    {
        public int State { get; }

        public string Text { get; }

        public Output(int state, string text)
        {
            State = state;
            Text = text;
        }

        public override string ToString() => $"({State}, '{Text}')";
    }
}
