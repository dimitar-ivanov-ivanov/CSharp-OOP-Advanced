using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    protected AbstractCommand(IList<string> args, IManager manager)
    {
        Args = args;
        Manager = manager;
    }

    public IList<string> Args { get; }

    public IManager Manager { get; }

    public abstract string Execute();
}
