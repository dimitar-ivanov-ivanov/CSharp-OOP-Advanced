namespace BashSoft.IO
{
    using BashSoft.Attributes;
    using BashSoft.Contracts;
    using BashSoft.IO.Commands;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string command)
        {
            var data = command.Split(' ');
            var commandName = data[0].ToLower();

            try
            {
                IExecutable executable = this.ParseCommand(command, commandName, data);
                executable.Execute();
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            var parametersForConstruction = new object[]
            {
                input,data
            };

            var typeOfCommand =
                Assembly.GetExecutingAssembly()
                .GetTypes()
                .First(x => x.GetCustomAttributes(typeof(AliasAttribute))
                .Where(att => att.Equals(command))
                .ToArray().Length > 0);

            var typeOfInterpreter = typeof(CommandInterpreter);

            var exe = (Command)Activator.CreateInstance(typeOfCommand, parametersForConstruction);

            var fieldsOfCommand = typeOfCommand
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var fieldsOfInterpreter = typeOfInterpreter
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fieldsOfCommand)
            {
                var attr = field.GetCustomAttribute(typeof(InjectAttribute));

                if (attr != null)
                {
                    if (fieldsOfInterpreter.Any(x => x.FieldType == field.FieldType))
                    {
                        field.SetValue(exe,
                        fieldsOfInterpreter
                            .First(x => x.FieldType == field.FieldType)
                            .GetValue(this));
                    }
                }
            }

            return exe;
        }
    }
}