namespace Custom_List_Sorter.Contracts
{
    using System;

    public interface IEngine
    {
        void Run<T>(ICommandInterpreter<T> commandInterpreter)
            where T : IComparable<T>;
    }
}