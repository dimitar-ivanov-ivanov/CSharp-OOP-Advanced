namespace Custom_List_Iterator.Contracts
{
    using System;

    public interface IEngine
    {
        void Run<T>(ICommandInterpreter<T> commandInterpreter)
            where T : IComparable<T>;
    }
}
