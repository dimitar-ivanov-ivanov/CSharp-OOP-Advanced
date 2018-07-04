namespace ListyIterator.Contracts
{
    using System.Collections.Generic;

    public interface IListyIterator<T> : IEnumerator<T>
    {
        IList<T> Data { get; }

        bool HasNext();

        void Print();
    }
}