namespace Create_Library.Models
{
    using Create_Library.Contracts;
    using System.Collections.Generic;

    public class Library : ILibrary
    {
        private IList<IBook> books;

        public Library(params IBook[] books)
        {
            this.Books = new List<IBook>(books);
        }

        public IList<IBook> Books
        {
            get { return this.books; }
            private set { this.books = value; }
        }
    }
}