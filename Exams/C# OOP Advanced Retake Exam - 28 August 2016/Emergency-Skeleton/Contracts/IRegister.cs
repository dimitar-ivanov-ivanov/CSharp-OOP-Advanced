namespace Emergency_Skeleton.Contracts
{
    public interface IRegister<T>
    {
        void Enqueue(T emergency);

        T Dequeue();

        int Count { get; }

        T Peek();

        bool IsEmpty();
    }
}
