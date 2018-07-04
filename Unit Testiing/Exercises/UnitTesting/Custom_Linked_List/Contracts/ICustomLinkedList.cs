namespace Custom_Linked_List.Contracts
{
    public interface ICustomLinkedList<T>
    {
        INode<T> First { get; }

        INode<T> Last { get; }

        int Count { get; }

        void Add(T value);

        T RemoveAt(int index);

        int Remove(T item);

        int IndexOf(T item);

        bool Contains(T item);
    }
}
