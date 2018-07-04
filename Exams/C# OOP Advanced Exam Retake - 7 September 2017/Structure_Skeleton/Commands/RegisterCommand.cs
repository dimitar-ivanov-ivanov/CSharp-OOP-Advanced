using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class RegisterCommand : Command
{
    public RegisterCommand(IList<string> arguments, IProviderController providerController,
        IHarvesterController harvesterController) 
        : base(arguments, providerController, harvesterController)
    {
    }

    public override string Execute()
    {
        var argsToPass = this.Arguments.Skip(1).ToList();

        if(argsToPass.Count == 4)
        {
            return this.HarvesterController.Register(argsToPass);
        }
        else
        {
            return this.ProviderController.Register(argsToPass);
        }
    }
}
