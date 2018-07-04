using System.Collections.Generic;

public interface IHeroFactory
{
    IHero CreateHero(IList<string> arguments);
}
