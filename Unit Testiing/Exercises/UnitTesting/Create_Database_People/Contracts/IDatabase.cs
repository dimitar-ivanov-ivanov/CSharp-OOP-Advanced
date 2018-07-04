namespace Create_Database_People.Contracts
{
    using Create_Database_People.Models;

    public interface IDatabase
    {
        int Count { get; }

        Person Last { get; }

        Person[] Data { get; }

        void Add(Person val);

        Person Remove();

        Person[] Fetch();

        Person FetchByUsername(string name);

        Person FetchById(long id);
    }
}
