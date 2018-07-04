using System;

public class Engine
{
    private const string TerminatingCommand = "Shutdown";

    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, 
        IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            var input = reader.ReadLine();
            var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var res = commandInterpreter.ProcessCommand(args);

            writer.WriteLine(res);

            if(args[0] == TerminatingCommand)
            {
                break;
            }
        }
    }
}
