using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private IDictionary<string, int> ammunitions;
    private IAmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.ammunitions = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }

    public void AddAmmunition(string name, int count)
    {
        if (!ammunitions.ContainsKey(name))
        {
            ammunitions.Add(name, 0);
        }

        ammunitions[name] += count;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    private bool TryEquipSoldier(ISoldier soldier)
    {
        var weaponsToTake = soldier.Weapons.Where(x => x.Value == null)
                    .Select(x => x.Key).ToList();

        var isEquiped = true;

        foreach (var weapon in weaponsToTake)
        {
            if(ammunitions.ContainsKey(weapon)  &&
               ammunitions[weapon] > 0)
            {
                ammunitions[weapon]--;
                var ammo = ammunitionFactory.CreateAmmunition(weapon);
                soldier.Weapons.Add(weapon, ammo);
            }
            else
            {
                isEquiped = false;
            }
        }

        return isEquiped;
    }
}
