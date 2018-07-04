namespace Create_Database_People.Models
{
    public class Person
    {
        private string name;
        private long id;

        public Person(string name, long id)
        {
            this.name = name;
            this.id = id;
        }

        public string Name { get => name; set => name = value; }

        public long Id { get => id; set => id = value; }

        public override bool Equals(object obj)
        {
            var other = obj as Person;
            return this.Name.Equals(other.Name) &&
                   this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Id}";
        }
    }
}
