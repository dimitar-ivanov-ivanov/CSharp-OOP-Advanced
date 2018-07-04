namespace Comparable_Book.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IBook : IComparable<IBook>
    {
        string Title { get; }

        int Year { get; }

        IList<string> Authors { get; }
    }
}