namespace Custom_Linked_List.Models
{
    using Custom_Linked_List.Contracts;

    public class Node<T> : INode<T>
    {
        private T value;

        public Node(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get { return this.value; }
            private set { this.value = value; }
        }

        public INode<T> Previous { get; set; }

        public INode<T> Next { get; set; }

        public override bool Equals(object obj)
        {
            var other = new Node<T>((T)obj);
            return this.Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
