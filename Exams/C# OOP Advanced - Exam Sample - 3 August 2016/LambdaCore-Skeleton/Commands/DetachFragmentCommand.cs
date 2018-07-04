namespace LambdaCore_Skeleton.Commands
{
    using System.Collections.Generic;
    using LambdaCore_Skeleton.Contracts;

    public class DetachFragmentCommand : Command
    {
        public DetachFragmentCommand(IList<string> args, IPowerPlant powerPlant) : base(args, powerPlant)
        {
        }

        public override string Execute()
        {
            return this.PowerPlant.DetachFragment();
        }
    }
}
