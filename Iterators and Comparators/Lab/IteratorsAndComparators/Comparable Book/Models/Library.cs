namespace Comparable_Book.Models
{
    using Comparable_Book.Contracts;
    using System.Collections;
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

        public IEnumerator<IBook> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<IBook>
        {
            private readonly IList<IBook> books;
            private int currentIndex;

            public LibraryIterator(IList<IBook> books)
            {
                this.books = books;
                this.Reset();
            }

            public IList<IBook> Books
            {
                get { return this.books; }
            }

            public int CurrentIndex
            {
                get { return this.currentIndex; }
                private set { this.currentIndex = value; }
            }

            public IBook Current
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