namespace Custom_List.Contracts
{
    using System;

    public interface IEngine
    {
        void Run<T>(ICommandInterpreter<T> commandInterpreter)
            where T : IComparable<T>;
    }
}
