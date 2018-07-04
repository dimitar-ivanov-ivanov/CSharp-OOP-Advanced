namespace Comparing_Objects.Models
{
    using Comparing_Objects.Contracts;

    public class Person : IPerson
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.name = name;
            this.age = age;
            this.town = town;
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

        public string Town
        {
            get { return this.town; }
            private set { this.town = value; }
        }

        public int CompareTo(IPerson other)
        {
            if (this.Name != other.Name)
            {
                return this.Name.CompareTo(other.Name);
            }

            if (this.Age != other.Age)
            {
                return this.Age.CompareTo(other.Age);
            }

            return this.Town.CompareTo(other.Town);
        }

        public override bool Equals(object obj)
        {
            var person = (Person)obj;

            return person.Name.Equals(this.Name) &&
                   person.Town.Equals(this.Town) &&
                   person.Age.Equals(this.Age);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Town}";
        }
    }
}
