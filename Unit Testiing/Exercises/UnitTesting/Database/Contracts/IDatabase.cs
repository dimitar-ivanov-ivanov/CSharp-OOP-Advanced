namespace Create_Database.Contracts
{
    public interface IDatabase
    {
        int Count { get; }

        int Last { get; }

        int[] Data { get; }

        void Add(int val);

        int Remove();

        int[] Fetch();
    }
}
