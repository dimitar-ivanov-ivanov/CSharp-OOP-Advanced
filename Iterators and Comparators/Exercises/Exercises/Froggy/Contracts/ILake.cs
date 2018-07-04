namespace Froggy.Contracts
{
    using System.Collections.Generic;

    public interface ILake<T>  : IEnumerable<int>
    {
        IList<int> Data { get; }
    }
}
