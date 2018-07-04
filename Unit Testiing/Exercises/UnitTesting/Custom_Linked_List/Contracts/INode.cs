namespace Custom_Linked_List.Contracts
{
    public interface INode<T>
    {
        T Value { get; }

        INode<T> Previous { get; set; }

        INode<T> Next { get; set; }
    }
}
