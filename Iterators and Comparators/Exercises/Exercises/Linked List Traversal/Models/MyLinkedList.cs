namespace Linked_List_Traversal.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using Linked_List_Traversal.Contracts;

    public class MyLinkedList<T> : IMyLinkedList<T>
    {
        private INode<T> first;
        private INode<T> last;
        private int count;

        public MyLinkedList()
        {
            this.count = 0;
        }

        public INode<T> First
        {
            get { return this.first; }
            private set { this.first = value; }
        }

        public INode<T> Last
        {
            get { return this.last; }
            private set { this.last = value; }
        }

        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        public void Add(T item)
        {
            var newNode = new Node<T>(item);

            if (this.Count == 0)
            {
                this.First = this.Last = newNode;
            }
            else
            {
                this.Last.Next = newNode;
                newNode.Previous = this.Last;
                this.Last = newNode;
            }

            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.First;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            var current = this.First;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    var prev = current.Previous;
                    var next = current.Next;

                    if(prev != null)
                    {
                        prev.Next = next;
                    }

                    if(next != null)
                    {
                        next.Previous = prev;
                    }

                    this.Count--;

                    if(current == this.First)
                    {
                        this.First = current.Next;
                    }

                    if(current == this.Last)
                    {
                        this.Last = current.Previous;
                    }

                    current.Next = null;
                    current.Previous = null;

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
