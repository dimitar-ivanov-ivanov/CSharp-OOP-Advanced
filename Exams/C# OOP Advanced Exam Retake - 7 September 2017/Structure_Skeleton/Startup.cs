public class Startup
{
    public static void Main(string[] args)
    {
        var harvesterFactory = new HarvesterFactory();
        var providerFactory = new ProviderFactory();
        var energyRepository = new EnergyRepository();

        var harvesterController = new HarvesterController(harvesterFactory, energyRepository);
        var providerController = new ProviderController(energyRepository);

        var commandInterpreter = new CommandInterpreter(harvesterController, providerController);

        var reader = new ConsoleReader();
        var writer = new ConsoleWriter();

        Engine engine = new Engine(commandInterpreter, reader, writer);
        engine.Run();
    }
}