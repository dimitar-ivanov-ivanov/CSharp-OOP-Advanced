namespace Linked_List_Traversal.Models
{
    using Linked_List_Traversal.Contracts;

    public class Node<T> : INode<T>
    {
        private T value;
        private INode<T> previous;
        private INode<T> next;

        public Node(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get { return this.value; }
            private set { this.value = value; }
        }

        public INode<T> Previous
        {
            get { return this.previous; }
            set { this.previous = value; }
        }

        public INode<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
    }
}
