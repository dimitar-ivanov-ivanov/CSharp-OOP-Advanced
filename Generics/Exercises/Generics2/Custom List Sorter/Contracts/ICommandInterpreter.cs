namespace Custom_List_Sorter.Contracts
{
    using System;

    public interface ICommandInterpreter<T>
         where T : IComparable<T>
    {
        ICustomList<T> CustomList { get; }

        void Add(T element);

        T Remove(int index);

        bool Contains(T element);

        void Swap(int index1, int index2);

        int Greater(T element);

        T Max();

        T Min();

        string Print();

        void Sort();
    }
}
