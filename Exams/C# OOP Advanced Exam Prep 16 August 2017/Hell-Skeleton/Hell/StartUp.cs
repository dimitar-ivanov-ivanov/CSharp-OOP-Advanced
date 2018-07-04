public class StartUp
{
    public static void Main()
    {
        var reader = new ConsoleReader();
        var writer = new ConsoleWriter();
        var heroFactory = new HeroFactory();
        var itemFactory = new ItemFactory();
        var manager = new HeroManager(heroFactory, itemFactory);

        var engine = new Engine(reader, writer, manager);
        engine.Run();
    }
}