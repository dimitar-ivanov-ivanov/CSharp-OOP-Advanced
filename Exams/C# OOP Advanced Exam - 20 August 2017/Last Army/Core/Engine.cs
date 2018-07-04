public class Engine
{
    private const string TerminatingCommand = "Enough! Pull back!";

    private IReader reader;
    private IWriter writer;
    private GameController gameController;

    public Engine(IReader reader, IWriter writer, GameController gameController)
    {
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        var input = reader.ReadLine();

        while(input != TerminatingCommand)
        {
            gameController.GiveInputToGameController(input);

            input = reader.ReadLine();
        }

        writer.WriteLine(gameController.RequestResult());
    }
}
