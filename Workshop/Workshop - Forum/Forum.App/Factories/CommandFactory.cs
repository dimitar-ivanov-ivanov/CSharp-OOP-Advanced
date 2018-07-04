namespace Forum.App.Factories
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandFactory : ICommandFactory
    {
        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var commandType = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName + "Command");

            if (commandType == null)
            {
                throw new InvalidOperationException("Command not found!");
            }

            if (!typeof(ICommand).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException($"{commandName} is not a command!");
            }

            var ctorParams = commandType.GetConstructors().First().GetParameters();

            var args = new object[ctorParams.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            var command = (ICommand)Activator.CreateInstance(commandType, args);

            return command;
        }
    }
}
