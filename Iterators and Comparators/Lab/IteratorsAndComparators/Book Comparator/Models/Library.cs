namespace Book_Comparator.Models
{
    using Book_Comparator.Contracts;
    using System.Collections;
    using System.Collections.Generic;

    public class Library : ILibrary
    {
        private IList<Book> books;

        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }

        public IList<Book> Books
        {
            get { return this.books; }
            private set { this.books = value; }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly IList<Book> books;
            private int currentIndex;

            public LibraryIterator(IList<Book> books)
            {
                this.books = books;
                this.Reset();
            }

            public IList<Book> Books
            {
                get { return this.books; }
            }

            public int CurrentIndex
            {
                get { return this.currentIndex; }
                private set { this.currentIndex = value; }
            }

            public Book Current
            {
                get { return this.Books[this.CurrentIndex]; }
                private set { this.Books[this.CurrentIndex] = value; }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            { }

            public bool MoveNext()
            {
                if (this.CurrentIndex + 1 < this.Books.Count)
                {
                    this.CurrentIndex++;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                this.CurrentIndex = -1;
            }
        }

    }
}