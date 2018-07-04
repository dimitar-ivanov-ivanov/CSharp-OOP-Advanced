namespace Generic_Box.Models
{
    using Generic_Box.Contracts;
    using System;

    public class Box<T> : IBox<T>
        where T : IComparable<T>
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

        public int CompareTo(IBox<T> other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}
