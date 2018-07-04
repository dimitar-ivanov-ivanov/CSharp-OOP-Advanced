namespace Tuple.Models
{
    using Tuple.Contracts;

    public class Tuple<T, U> : ITuple<T, U>
    {
        private T item1;
        private U item2;

        public Tuple(T item1,U item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public T Item1
        {
            get { return this.item1; }
            set { this.item1 = value; }
        }

        public U Item2
        {
            get { return this.item2; }
            set { this.item2 = value; }
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2}";
        }
    }
}
