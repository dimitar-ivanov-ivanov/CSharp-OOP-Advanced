namespace FestivalManager.Core
{
    using FestivalManager.Core.Contracts;
    using FestivalManager.Core.Controllers;
    using System.Linq;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Core.IO.Contracts;
    using System;
    using System.Reflection;
    using FestivalManager.Core.IO;
    using FestivalManager.Entities.Contracts;

    public class Engine : IEngine
    {
        private const string TerminatingCommand = "END";

        public IReader reader;
        public IWriter writer;

        public IFestivalController festivalCоntroller;
        public ISetController setCоntroller;

        public Engine(IStage stage)
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            this.festivalCоntroller = new FestivalController(stage);
            this.setCоntroller = new SetController(stage);
        }

        public void Run()
        {
            //TODO use stringbuilder??
            var input = reader.ReadLine();

            while (input != TerminatingCommand)
            {

                try
                {
                    writer.WriteLine(ProcessCommand(input));
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }

                    writer.WriteLine("ERROR: " + ex.Message);
                }

                input = reader.ReadLine();
            }

            writer.WriteLine("Results:");
            writer.WriteLine(festivalCоntroller.ProduceReport());
        }

        public string ProcessCommand(string input)
        {
            if (input == "LetsRock")
            {
                return setCоntroller.PerformSets();
            }

            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var methodName = args[0];
            args = args.Skip(1).ToArray();

            var methodToInvoke = this.festivalCоntroller
                .GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Static |
                 BindingFlags.Public | BindingFlags.Instance)
                .FirstOrDefault(x => x.Name == methodName);

            return (string)methodToInvoke.Invoke(this.festivalCоntroller, new object[] { args });
        }
    }
}