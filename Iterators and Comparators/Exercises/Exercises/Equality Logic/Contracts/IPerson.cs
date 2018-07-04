namespace Equality_Logic.Contracts
{
    using System;

    public interface IPerson : IComparable<IPerson>
    {
        string Name { get; }

        int Age { get; }
    }
}
