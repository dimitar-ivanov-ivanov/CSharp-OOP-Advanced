using System.Collections.Generic;

public class ShutdownCommand : Command
{
    public ShutdownCommand(IList<string> arguments, IProviderController providerController, IHarvesterController harvesterController) : base(arguments, providerController, harvesterController)
    {
    }

    public override string Execute()
    {
        return "System Shutdown\n" + 
               $"Total Energy Produced: {this.ProviderController.TotalEnergyProduced}\n" + 
               $"Total Mined Plumbus Ore: {this.HarvesterController.OreProduced}";
    }
}
