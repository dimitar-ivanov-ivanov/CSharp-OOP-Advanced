using System.Collections.Generic;

public interface IItemFactory
{
    IItem CreateItem(IList<string> args);
}
