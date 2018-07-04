namespace Threeuple.Contracts
{
    public interface IThreeuple<T, U, V>
    {
        T Item1 { get; }

        U Item2 { get; }

        V Item3 { get; }
    }
}
