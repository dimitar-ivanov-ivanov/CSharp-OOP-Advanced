using System.Collections.Generic;
using System.Linq;

public class ItemFactory : IItemFactory
{
    public IItem CreateItem(IList<string> args)
    {
        var type = args[0];
        var name = args[1];
        var strengthBonus = long.Parse(args[2]);
        var agilityBonus = long.Parse(args[3]);
        var intelligenceBonus = long.Parse(args[4]);
        var hitpointsBonus = long.Parse(args[5]);
        var damageBonus = long.Parse(args[6]);

        if (type == "Item")
        {
            return new CommonItem(name, strengthBonus, agilityBonus,
                 intelligenceBonus, hitpointsBonus, damageBonus);
        }
        else
        {
            var itemNames = args.Skip(7).ToArray();

            return new RecipeItem(name, strengthBonus, agilityBonus, intelligenceBonus,
                hitpointsBonus, damageBonus, itemNames);
        }
    }
}

