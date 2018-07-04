namespace LambdaCore_Skeleton.Commands
{
    using System.Collections.Generic;
    using LambdaCore_Skeleton.Contracts;

    public class SelectCoreCommand : Command
    {
        public SelectCoreCommand(IList<string> args, IPowerPlant powerPlant) : base(args, powerPlant)
        {
        }

        public override string Execute()
        {
            var name = this.Args[0];
            return this.PowerPlant.SelectCore(name);
        }
    }
}
