namespace LambdaCore_Skeleton.Core
{
    using LambdaCore_Skeleton.Contracts;
    using System;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICommandInterpreter commandInterpreter;

        private const string TerminatingCommand = "System Shutdown!";

        public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            var input = reader.ReadLine();

            while (input != TerminatingCommand)
            {
                var args = input.Split(new[] { ':', '@' }, StringSplitOptions.RemoveEmptyEntries);

                var result = commandInterpreter.InterpretCommand(args);

                writer.WriteLine(result);

                input = reader.ReadLine();
            }
        }
    }
}
