namespace Comparable_Book.Models
{
    using Comparable_Book.Contracts;
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
            if (this.Year != other.Year)
            {
                return this.Year.CompareTo(other.Year);
            }

            return this.Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}