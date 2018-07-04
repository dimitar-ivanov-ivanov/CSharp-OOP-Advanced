namespace Custom_List_Sorter.Models
{
    using Custom_List_Sorter.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomList<T>
        : ICustomList<T>
        where T : IComparable<T>
    {
        private IList<T> data;

        public CustomList(IList<T> data)
        {
            this.data = data;
        }

        public CustomList()
        {
            this.data = new List<T>();
        }

        public IList<T> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public void Add(T element)
        {
            this.Data.Add(element);
        }

        public bool Contains(T element)
        {
            return this.Data.Contains(element);
        }

        public int CountGreaterThan(T element)
        {
            return Data
                .Where(x => x.CompareTo(element) == 1)
                 .Count();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.Data)
            {
                yield return item;
            }
        }

        public T Max()
        {
            return this.Data.Max();
        }

        public T Min()
        {
            return this.Data.Min();
        }

        public T Remove(int index)
        {
            var toRemove = this.Data[index];
            this.Data.RemoveAt(index);
            return toRemove;
        }

        public void Swap(int index1, int index2)
        {
            var temp = this.Data[index1];
            this.Data[index1] = this.Data[index2];
            this.Data[index2] = temp;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
