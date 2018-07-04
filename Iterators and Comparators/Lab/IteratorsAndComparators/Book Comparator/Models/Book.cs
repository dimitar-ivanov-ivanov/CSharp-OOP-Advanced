namespace Book_Comparator.Models
{
    using Book_Comparator.Contracts;
    using System.Collections.Generic;

    public class Book : IBook
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);
        }

        public string Title { get; private set; }

        public int Year { get; private set; }

        public IList<string> Authors { get; private set; }

        public int CompareTo(IBook other)
        {
            return new BookComparator().Compare(this, other);
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}