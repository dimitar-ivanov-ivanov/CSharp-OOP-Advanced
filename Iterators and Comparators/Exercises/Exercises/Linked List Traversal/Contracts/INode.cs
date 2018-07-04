namespace Linked_List_Traversal.Contracts
{
    public interface INode<Т>
    {
        Т Value { get; }

        INode<Т> Previous { get; set; }

        INode<Т> Next { get; set; }
    }
}
