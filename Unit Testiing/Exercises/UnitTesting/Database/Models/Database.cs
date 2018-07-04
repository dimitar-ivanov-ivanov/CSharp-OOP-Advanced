namespace Create_Database.Models
{
    using Create_Database.Contracts;
    using System;
    using System.Linq;

    public class Database : IDatabase
    {
        private int[] data;
        private int index;

        public Database(int[] data)
        {
            this.data = new int[Capacity];
            this.Data = data;
        }

        public int Capacity = 16;

        public int Count => index;

        public int Last => this.Data[index - 1];

        public int[] Data
        {
            get { return this.data; }
            private set
            {
                if(value.Length > Capacity)
                {
                    throw new InvalidOperationException("Data length must not exceed capacity.");
                }

                foreach (var item in value)
                {
                    this.data[index++] = item;
                }
            }
        }
        
        public void Add(int val)
        {
            if(this.Count == Capacity)
            {
                throw new InvalidOperationException("Adding an element exceeds capacity.");
            }

            this.data[index++] = val;
        }

        public int Remove()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException("Removing from empty database is impossible.");
            }

            var toRemove = this.data[index - 1];
            this.data[--index] = 0;
            return toRemove;
        }

        public int[] Fetch()
        {
            return this.Data.ToArray();
        }
    }
}
