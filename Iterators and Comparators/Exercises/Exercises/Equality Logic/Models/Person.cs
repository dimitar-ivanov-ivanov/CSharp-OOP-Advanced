namespace Equality_Logic.Models
{
    using Equality_Logic.Contracts;

    public class Person : IPerson
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            private set { this.age = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }

        public override bool Equals(object obj)
        {
            var person = (Person)obj;

            return person.Name.Equals(this.Name) &&
                   person.Age.Equals(this.Age);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public int CompareTo(IPerson other)
        {
            if (this.Name != other.Name)
            {
                return this.Name.CompareTo(other.Name);
            }

            return this.Age.CompareTo(other.Age);
        }
    }
}