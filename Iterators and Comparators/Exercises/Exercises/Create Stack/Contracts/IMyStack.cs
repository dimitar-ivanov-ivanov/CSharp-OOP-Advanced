namespace Create_Stack.Contracts
{
    using System.Collections.Generic;

    public interface IMyStack<T> : IEnumerable<T>
    {
        IList<T> Data { get; }

        void Push(params T[] elements);

        void Pop();
    }
}