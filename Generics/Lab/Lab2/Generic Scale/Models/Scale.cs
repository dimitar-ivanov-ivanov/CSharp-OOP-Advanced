namespace Generic_Scale.Models
{
    using System;
    using Generic_Scale.Contracts;

    public class Scale<T> : IScale<T>
           where T : IComparable<T>
    {
        private T left;
        private T right;

        public Scale(T left, T right)
        {
            this.Left = left;
            this.Right = right;
        }

        public T Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        public T Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

        public T GetHavier()
        {
            if (this.left.CompareTo(this.right) == 1)
            {
                return this.left;
            }
            else if (this.left.CompareTo(this.right) == -1)
            {
                return this.right;
            }
            else
            {
                return default(T);
            }
        }
    }
}