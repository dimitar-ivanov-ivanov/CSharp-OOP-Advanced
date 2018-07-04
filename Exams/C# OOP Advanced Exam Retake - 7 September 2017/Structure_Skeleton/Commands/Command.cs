using System.Collections.Generic;

public abstract class Command : ICommand
{
    protected Command(IList<string> arguments, IProviderController providerController,
        IHarvesterController harvesterController)
    {
        Arguments = arguments;
        ProviderController = providerController;
        HarvesterController = harvesterController;
    }

    public IList<string> Arguments { get; }

    public IProviderController ProviderController { get; }

    public IHarvesterController HarvesterController { get; }

    public abstract string Execute();
}
