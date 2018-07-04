namespace Comparable_Book
{
    using System;
    using System.Linq;
    using Comparable_Book.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryOne = new Library();
            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);

            foreach (var book in libraryTwo.OrderBy(x => x))
            {
                Console.WriteLine(book);
            }
        }
    }
}