namespace LambdaCore_Skeleton.Core
{
    using LambdaCore_Skeleton.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IPowerPlant powerPlant;
        private Type[] commands;

        private const string Suffix = "Command";

        public CommandInterpreter(IPowerPlant powerPlant)
        {
            this.powerPlant = powerPlant;

            this.commands = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.Name.EndsWith(Suffix))
                .ToArray();
        }

        public string InterpretCommand(IList<string> args)
        {
            var commandName = args[0];
            var paramsToPass = args.Skip(1).ToList();

            var commandType = this.commands.FirstOrDefault(x => x.Name == commandName + Suffix);
            var commandActivated = (ICommand)Activator.CreateInstance(commandType, paramsToPass, this.powerPlant);

            var result = commandActivated.Execute();

            return result;
        }
    }
}
