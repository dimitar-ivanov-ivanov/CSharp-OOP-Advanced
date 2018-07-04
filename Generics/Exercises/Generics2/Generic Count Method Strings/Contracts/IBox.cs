namespace Generic_Box.Contracts
{
    using System;

    public interface IBox<T> : IComparable<IBox<T>>
        where T : IComparable<T>
    {
        T Value { get; }
    }
}
