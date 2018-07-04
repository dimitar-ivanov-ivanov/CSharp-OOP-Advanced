namespace LambdaCore_Skeleton.Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class LStack<T> : IEnumerable<T>
    {
        private LinkedList<T> innerList;

        public LStack()
        {
            this.innerList = new LinkedList<T>();
        }

        public int Count()
        {
            return this.innerList.Count;
        }

        public T Push(T item)
        {
            if(item == null)
            {
                throw new ArgumentNullException();
            }

            this.innerList.AddLast(item);
            return item;
        }

        public T Pop()
        {
            if(!IsEmpty())
            {
                throw new InvalidOperationException();
            }

            var toRemove = this.innerList.Last.Value;
            this.innerList.RemoveLast();
            return toRemove;
        }

        public T Peek()
        {
            if (!IsEmpty())
            {
                throw new InvalidOperationException();
            }

            T peekedItem = this.innerList.First();
            return peekedItem;
        }

        public bool IsEmpty()
        {
            return this.innerList.Count > 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.innerList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
