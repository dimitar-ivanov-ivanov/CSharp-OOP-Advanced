namespace Create_Collection.Contracts
{
    using System.Collections.Generic;

    public interface IListyIterator<T> : IEnumerator<T>, IEnumerable<T>
    {
        IList<T> Data { get; }

        bool HasNext();

        void Print();

        void PrintAll();
    }
}
