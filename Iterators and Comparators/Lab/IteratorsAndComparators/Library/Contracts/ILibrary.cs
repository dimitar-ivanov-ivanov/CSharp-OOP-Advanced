namespace Create_Library.Contracts
{
    using System.Collections.Generic;

    public interface ILibrary
    {
        IList<IBook> Books { get; }
    }
}