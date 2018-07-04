using System.Collections.Generic;
using System.Linq;

public class Army : IArmy
{
    private IList<ISoldier> soldiers;

    public Army()
    {
        this.soldiers = new List<ISoldier>();
    }

    public IReadOnlyList<ISoldier> Soldiers => (IReadOnlyList<ISoldier>)soldiers;

    public void AddSoldier(ISoldier soldier)
    {
        this.soldiers.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        foreach (var soldier in this.soldiers
            .Where(x => x.GetType().Name == soldierType))
        {
            soldier.Regenerate();
        }
    }
}
