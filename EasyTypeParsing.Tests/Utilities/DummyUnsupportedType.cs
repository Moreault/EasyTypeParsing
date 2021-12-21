namespace EasyTypeParsing.Tests.Utilities
{
    internal record DummyUnsupportedType : IComparable, IComparable<DummyUnsupportedType>
    {
        public int A { get; init; }
        public string? B { get; init; }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(DummyUnsupportedType? other)
        {
            throw new NotImplementedException();
        }
    }
}