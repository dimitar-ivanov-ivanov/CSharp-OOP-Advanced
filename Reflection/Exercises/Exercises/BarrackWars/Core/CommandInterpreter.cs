namespace BarrackWars.Core
{
    using BarrackWars.Attributes;
    using BarrackWars.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";

        private IRepository repository;
        private IUnitFactory unitFactory;

        private const BindingFlags Flags = BindingFlags.Public |
            BindingFlags.NonPublic | BindingFlags.Static |
            BindingFlags.Instance;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var result = string.Empty;

            var commandToFind = commandName + Suffix;

            var allTypes = Assembly.GetExecutingAssembly().GetTypes();

            var commandType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.Equals(commandToFind,
                StringComparison.OrdinalIgnoreCase));

            var activatedCommand = (IExecutable)Activator.CreateInstance(commandType,
                new object[] { data });

            InjectFields(commandType, activatedCommand);

            return activatedCommand;
        }

        private void InjectFields(Type comandType, IExecutable activatedCommand)
        {
            var fieldsToInject = comandType
                .GetFields(Flags)
                .Where(x => x.GetCustomAttribute<InjectAttribute>() != null);

            var interpreterFields = this
                .GetType()
                .GetFields(Flags);

            foreach (var field in fieldsToInject)
            {
                var fieldValueToInject =
                    interpreterFields
                    .FirstOrDefault(x => x.FieldType == field.FieldType)
                    .GetValue(this);

                field.SetValue(activatedCommand, fieldValueToInject);
            }
        }
    }
}