using System.Collections.Generic;

public class ModeCommand : Command
{
    public ModeCommand(IList<string> arguments, IProviderController providerController, IHarvesterController harvesterController) : base(arguments, providerController, harvesterController)
    {
    }

    public override string Execute()
    {
        var mode = this.Arguments[0];

        return this.HarvesterController.ChangeMode(mode);
    }
}
