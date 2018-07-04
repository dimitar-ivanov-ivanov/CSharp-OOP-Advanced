namespace LambdaCore_Skeleton.Contracts
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string Execute();

        IList<string> Args { get; }

        IPowerPlant PowerPlant { get; }
    }
}
