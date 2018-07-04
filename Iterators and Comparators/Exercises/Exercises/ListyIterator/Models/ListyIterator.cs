namespace ListyIterator.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using ListyIterator.Contracts;

    public class ListyIterator<T> : IListyIterator<T>
    {
        private IList<T> data;
        private int index;

        public ListyIterator(IList<T> data)
        {
            this.data = data;
            Reset();
        }

        public IList<T> Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public T Current => this.Data[index];

        object IEnumerator.Current => this.Data[index];

        public void Dispose()
        { }

        public bool MoveNext()
        {
            if (HasNext())
            {
                index++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            if(this.index >= this.data.Count - 1)
            {
                return false;
            }

            return true; ;
        }

        public void Reset()
        {
            this.index = 0;
        }

        public void Print()
        {
            if (this.index >= this.Data.Count)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.Current);
        }
    }
}
