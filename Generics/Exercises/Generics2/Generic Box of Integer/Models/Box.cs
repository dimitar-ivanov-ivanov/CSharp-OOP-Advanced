namespace Generic_Box.Models
{
    using Generic_Box.Contracts;

    public class Box<T> : IBox<T>
    {
        private T value;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public Box(T value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{this.Value.GetType().FullName}: {this.Value}";
        }
    }
}
