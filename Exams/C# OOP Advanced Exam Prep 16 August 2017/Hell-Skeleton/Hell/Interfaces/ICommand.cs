using System.Collections;
using System.Collections.Generic;

public interface ICommand
{
    IList<string> Args { get; }

    IManager Manager { get; }

    string Execute();
}
