using System.Collections.Generic;

public class RepairCommand : Command
{
    public RepairCommand(IList<string> arguments, IProviderController providerController, IHarvesterController harvesterController) : base(arguments, providerController, harvesterController)
    {
    }

    public override string Execute()
    {
        var val = double.Parse(this.Arguments[0]);

        return this.ProviderController.Repair(val);
    }
}
