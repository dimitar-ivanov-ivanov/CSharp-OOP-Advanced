namespace Generic_Scale.Contracts
{
    public interface IScale<T>
    {
        T Left { get; }

        T Right { get; }

        T GetHavier();
    }
}