namespace Comparing_Objects.Models
{
    using Comparing_Objects.Contracts;

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
    }
}