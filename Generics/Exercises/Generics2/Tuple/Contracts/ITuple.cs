namespace Tuple.Contracts
{
    public interface ITuple<T, U>
    {
        T Item1 { get; }

        U Item2 { get; }
    }
}
