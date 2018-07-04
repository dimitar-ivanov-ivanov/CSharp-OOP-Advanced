namespace Create_Stack.Models
{
    using Create_Stack.Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyStack<T> : IMyStack<T>
    {
        private IList<T> data;

        public MyStack()
        {
            this.data = new List<T>();
        }

        public IList<T> Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Data.Count - 1; i >= 0; i--)
            {
                yield return this.Data[i];
            }
        }

        public void Pop()
        {
            if (this.Data.Count > 0)
            {
                this.Data.RemoveAt(this.Data.Count - 1);
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }

        public void Push(params T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.data.Add(elements[i]);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
