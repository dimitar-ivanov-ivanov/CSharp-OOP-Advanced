namespace Inferno_Infinity.Contracts
{
    public interface ICommandInterpreter
    {
        void Create(string[] args);

        void Add(string[] args);

        void Remove(string[] args);

        void Print(string[] args);
    }
}