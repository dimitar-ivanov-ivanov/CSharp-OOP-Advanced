namespace Create_Library_Iterator.Models
{
    using Create_Library_Iterator.Contracts;
    using System.Collections.Generic;

    public class Book : IBook
    {
        private string title;
        private int year;
        private IList<string> authors;

        public Book(string title, int year, params string[] authors)
        {
            this.title = title;
            this.year = year;
            this.authors = new List<string>(authors);
        }

        public string Title
        {
            get { return title; }
            private set { this.title = value; }
        }

        public int Year
        {
            get { return this.year; }
            private set { this.year = value; }
        }

        public IList<string> Authors
        {
            get { return this.authors; }
            private set { this.authors = value; }
        }

    }
}