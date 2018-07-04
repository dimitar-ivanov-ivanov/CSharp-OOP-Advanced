namespace BarrackWars
{
    using Core;
    using Core.Factories;
    using Data;

    public class AppEntryPoint
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var repository = new UnitRepository();
            var unitFactory = new UnitFactory();
            var commandInterpreter = new CommandInterpreter(repository, unitFactory);
            var engine = new Engine(repository, unitFactory, commandInterpreter);
            engine.Run();
        }
    }
}
