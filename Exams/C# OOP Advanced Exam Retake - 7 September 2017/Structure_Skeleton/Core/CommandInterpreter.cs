using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string Suffix = "Command";

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        HarvesterController = harvesterController;
        ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        var commandName = args[0] + Suffix;
        args = args.Skip(1).ToList();

        var typeToActivate = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == commandName);

        var command = (ICommand)Activator.CreateInstance
            (typeToActivate, args, ProviderController, HarvesterController);

        return command.Execute();
    }
}
