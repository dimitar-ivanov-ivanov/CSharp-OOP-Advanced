using System.Collections.Generic;

public class DayCommand : Command
{
    public DayCommand(IList<string> arguments, IProviderController providerController, IHarvesterController harvesterController) : base(arguments, providerController, harvesterController)
    {
    }

    public override string Execute()
    {
        var providerResult = ProviderController.Produce();
        var harvesterResult = HarvesterController.Produce();
        return providerResult + "\n" + harvesterResult;
    }
}
