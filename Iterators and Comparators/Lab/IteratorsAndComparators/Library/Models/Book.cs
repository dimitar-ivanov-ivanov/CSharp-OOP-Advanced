﻿namespace Create_Library.Models
{
    using Create_Library.Contracts;
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
    }
}