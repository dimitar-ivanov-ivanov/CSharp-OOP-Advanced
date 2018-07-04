namespace Custom_Linked_List.Models
{
    using Custom_Linked_List.Contracts;
    using System;

    public class CustomLinkedList<T> : ICustomLinkedList<T>
    {
        private INode<T> first;
        private INode<T> last;
        private int count;

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
            private set { this.count = value; }
        }

        public void Add(T value)
        {
            if(value == null)
            {
                throw new ArgumentNullException("Node value cannot be null.");
            }

            var newNode = new Node<T>(value);

            if (count == 0)
            {
                this.first = this.last = newNode;
            }
            else
            {
                this.last.Next = newNode;
                newNode.Previous = this.last;
                this.last = newNode;
            }

            this.count++;
        }

        public bool Contains(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("List cannot contain node value that's null.");
            }

            var index = IndexOf(item);
            return index != -1;
        }

        public int IndexOf(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("List cannot contain node value that's null.");
            }

            var currentNode = this.first;
            var index = 0;

            while (currentNode != null)
            {
                if (currentNode.Equals(item))
                {
                    break;
                }

                currentNode = currentNode.Next;
                index++;
            }

            if (currentNode == null)
            {
                return -1;
            }

            return index;
        }

        public int Remove(T item)
        {
            if(item == null)
            {
                throw new ArgumentNullException("Cannot remove a null item.");
            }

            var current = this.first;
            var index = 0;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    break;
                }

                current = current.Next;
                index++;
            }

            if (current != null)
            {
                RemoveListNode(current);
                return index;
            }

            return -1;
        }

        public T RemoveAt(int index)
        {
            if (index >= this.count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }

            var current = this.first;
            var currentIndex = 0;

            while (currentIndex < index)
            {
                current = current.Next;
                currentIndex++;
            }

            RemoveListNode(current);

            return current.Value;
        }

        private void RemoveListNode(INode<T> node)
        {
            var next = node.Next;
            var prev = node.Previous;

            this.count--;
            if (count == 0)
            {
                // The list becomes empty -> remove head and tail
                this.first = null;
                this.last = null;
            }

            if (prev == null)
            {
                // The head node was removed --> update the head
                this.first = next;
            }
            else if(prev  != null)
            {
                prev.Next = next;
            }

            if (next == null)
            {
                // Redirect the pointers to skip the removed node
                this.last = prev;
            }
            else if(next != null)
            {
                next.Previous = prev;
            }

            node.Previous = null;
            node.Next = null;
        }
    }
}