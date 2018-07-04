namespace Box_Of_T.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Box_Of_T.Contracts;

    public class Box<T> : IBox<T>
    {
        private IList<T> data;

        public int Count => data.Count;

        public Box()
        {
            this.data = new List<T>();
        }

        public Box(IList<T> data)
        {
            this.data = data;
        }

        public Box(params T[] data)
            : this(data.ToList())
        { }

        public void Add(T element)
        {
            data.Add(element);
        }

        public T Remove()
        {
            var last = data.LastOrDefault();
            data.RemoveAt(data.Count - 1);
            return last;
        }
    }
}