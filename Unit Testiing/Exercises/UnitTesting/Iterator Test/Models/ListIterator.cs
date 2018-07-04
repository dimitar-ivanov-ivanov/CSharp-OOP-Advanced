namespace Iterator_Test.Models
{
    using Iterator_Test.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ListIterator : IListIterator
    {
        private string[] data;
        private int index;

        public ListIterator(string[] data)
        {
            this.Data = data;
        }

        public object Current => this.Data[index];

        public int Count => this.Data.Length;

        private string[] Data
        {
            get { return this.data; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Data cannot be null.");
                }

                this.data = value;
            }
        }

        public string this[int index]
        {
            get
            {
                return this.Data[index];
            }
            set
            {
                this.Data[index] = value;
            }
        }

        public int Index { get => index; set => index = value; }

        public bool HasNext()
        {
            if (index + 1 == this.Count)
            {
                return false;
            }

            return true;
        }

        public bool MoveNext()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }

            return false;
        }

        public string Print()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

           return this.Data[index];
        }

        public void Reset()
        {
            this.index = 0;
        }

        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            foreach (var item in this.Data)
            {
                yield return item;
            }
        }
    }
}
