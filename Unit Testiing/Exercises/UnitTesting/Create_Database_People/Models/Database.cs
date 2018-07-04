namespace Create_Database_People.Models
{
    using Create_Database_People.Contracts;
    using System;
    using System.Linq;

    public class Database : IDatabase
    {
        private Person[] data;
        private int index;

        public Database(Person[] data)
        {
            this.data = new Person[Capacity];
            this.Data = data;
        }

        public int Capacity = 16;

        public int Count => index;

        public Person Last => this.Data[index - 1];

        public Person[] Data
        {
            get { return this.data; }
            private set
            {
                if (value.Length > Capacity)
                {
                    throw new InvalidOperationException("Data length must not exceed capacity.");
                }

                foreach (var item in value)
                {
                    this.data[index++] = item;
                }
            }
        }

        public void Add(Person val)
        {
            if (this.Count == Capacity)
            {
                throw new InvalidOperationException("Adding an element exceeds capacity.");
            }

            var existingPersonByName = this.data
                .Where(x => x != null)
                .FirstOrDefault(x => x.Name == val.Name);

            var existingPersonById = this.data
               .Where(x => x != null)
               .FirstOrDefault(x => x.Id == val.Id);


            if (existingPersonByName != null)
            {
                throw new InvalidOperationException("Person with equal name exists.");
            }

            if (existingPersonById != null)
            {
                throw new InvalidOperationException("Person with equal id exists.");
            }

            this.data[index++] = val;
        }

        public Person Remove()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Removing from empty database is impossible.");
            }

            var toRemove = this.data[index - 1];
            this.data[--index] = null;
            return toRemove;
        }

        public Person[] Fetch()
        {
            return this.Data.ToArray();
        }

        public Person FetchByUsername(string name)
        {
            if (name == null)
            {
                throw new ArgumentException("Name cannot be null.");
            }

            var person = this.Data
                .Where(x => x != null)
                .FirstOrDefault(x => x.Name == name);

            if (person == null)
            {
                throw new InvalidOperationException("Person with name doesn't exist.");
            }

            return person;
        }

        public Person FetchById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id cannot be negative.");
            }

            var person = this.Data
                           .Where(x => x != null)
                           .FirstOrDefault(x => x.Id == id);

            if(person == null)
            {
                throw new InvalidOperationException("User with id doesn't exists.");
            }

            return person;
        }
    }
}
