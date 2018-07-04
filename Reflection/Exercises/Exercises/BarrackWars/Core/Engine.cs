namespace BarrackWars.Core
{
    using System;
    using Contracts;

    public class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        private ICommandInterpreter commandInterpreter;

        public Engine(IRepository repository, IUnitFactory unitFactory,
            ICommandInterpreter commandInterpreter)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    var data = input.Split();
                    var commandName = data[0];
                    var result = commandInterpreter.InterpretCommand(data, commandName);
                    Console.WriteLine(result.Execute());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}