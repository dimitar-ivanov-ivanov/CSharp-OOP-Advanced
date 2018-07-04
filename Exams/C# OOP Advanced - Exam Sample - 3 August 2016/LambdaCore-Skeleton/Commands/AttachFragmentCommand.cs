namespace LambdaCore_Skeleton.Commands
{
    using System.Collections.Generic;
    using LambdaCore_Skeleton.Contracts;

    public class AttachFragmentCommand : Command
    {
        public AttachFragmentCommand(IList<string> args, IPowerPlant powerPlant) : base(args, powerPlant)
        {
        }

        public override string Execute()
        {
            var name = this.Args[1];
            var type = this.Args[0];
            var pressureAffection = int.Parse(this.Args[2]);

            return this.PowerPlant.AttachFragment(name, type, pressureAffection);
        }
    }
}
