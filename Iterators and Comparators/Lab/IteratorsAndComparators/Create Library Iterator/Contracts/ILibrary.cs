namespace Create_Library_Iterator.Contracts
{
    using Create_Library_Iterator.Models;
    using System.Collections.Generic;

    public interface ILibrary : IEnumerable<IBook>
    {
        IList<IBook> Books { get; }
    }
}