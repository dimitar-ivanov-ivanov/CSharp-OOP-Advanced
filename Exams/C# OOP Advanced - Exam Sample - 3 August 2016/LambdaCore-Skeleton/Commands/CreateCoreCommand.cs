namespace LambdaCore_Skeleton.Commands
{
    using System.Collections.Generic;
    using LambdaCore_Skeleton.Contracts;

    public class CreateCoreCommand : Command
    {
        public CreateCoreCommand(IList<string> args, IPowerPlant powerPlant) : base(args, powerPlant)
        {
        }

        public override string Execute()
        {
            var type = this.Args[0];
            var durability = int.Parse(this.Args[1]);

            return this.PowerPlant.CreateCore(type, durability);
        }
    }
}
