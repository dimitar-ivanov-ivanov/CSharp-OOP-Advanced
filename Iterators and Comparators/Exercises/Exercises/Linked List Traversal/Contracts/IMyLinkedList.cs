namespace Linked_List_Traversal.Contracts
{
    using System.Collections.Generic;

    public interface IMyLinkedList<T>
        : IEnumerable<T>
    {
        INode<T> First { get; }

        INode<T> Last { get; }

        void Add(T item);

        bool Remove(T item);

        int Count { get; }
    }
}
