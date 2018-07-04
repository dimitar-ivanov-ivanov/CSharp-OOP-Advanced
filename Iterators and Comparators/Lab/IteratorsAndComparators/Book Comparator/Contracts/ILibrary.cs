namespace Book_Comparator.Contracts
{
    using Book_Comparator.Models;
    using System.Collections.Generic;

    public interface ILibrary : IEnumerable<Book>
    {
        IList<Book> Books { get; }
    }
}