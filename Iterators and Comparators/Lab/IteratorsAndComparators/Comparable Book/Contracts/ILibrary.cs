namespace Comparable_Book.Contracts
{
    using System.Collections.Generic;

    public interface ILibrary : IEnumerable<IBook>
    {
        IList<IBook> Books { get; }
    }
}