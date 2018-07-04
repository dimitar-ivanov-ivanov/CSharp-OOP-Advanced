namespace Book_Comparator.Models
{
    using Book_Comparator.Contracts;
    using System.Collections.Generic;

    public class BookComparator : IComparer<IBook>
    {
        public int Compare(IBook first, IBook second)
        {
            if (first.Title != second.Title)
            {
                return first.Title.CompareTo(second.Title);
            }

            return second.Year.CompareTo(first.Year);
        }
    }
}