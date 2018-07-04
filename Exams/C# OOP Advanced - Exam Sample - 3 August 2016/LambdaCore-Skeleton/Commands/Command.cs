namespace LambdaCore_Skeleton.Commands
{
    using System.Collections.Generic;
    using LambdaCore_Skeleton.Contracts;

    public abstract class Command : ICommand
    {
        protected Command(IList<string> args, IPowerPlant powerPlant)
        {
            Args = args;
            this.PowerPlant = powerPlant;
        }

        public IList<string> Args { get; }

        public IPowerPlant PowerPlant { get; }

        public abstract string Execute();
    }
}
