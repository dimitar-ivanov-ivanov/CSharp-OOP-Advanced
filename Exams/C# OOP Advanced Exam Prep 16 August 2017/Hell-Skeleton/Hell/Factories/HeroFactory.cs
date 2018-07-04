using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HeroFactory : IHeroFactory
{
    public IHero CreateHero(IList<string> arguments)
    {
        var heroName = arguments[1];
        var heroType = arguments[2];

        var type = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == heroType);

        var constr = type.GetConstructor(new[] { typeof(string) });

        var hero = (IHero)constr.Invoke(new object[] { heroName });

        return hero;
    }
}
