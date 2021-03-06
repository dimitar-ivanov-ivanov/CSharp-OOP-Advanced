﻿namespace Custom_List_Iterator.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ICustomList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        void Add(T element);

        T Remove(int index);

        bool Contains(T element);

        void Swap(int index1, int index2);

        int CountGreaterThan(T element);

        T Max();

        T Min();

        IList<T> Data { get; }
    }
}
