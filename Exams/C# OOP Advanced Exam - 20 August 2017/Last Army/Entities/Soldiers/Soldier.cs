using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const int InitialRegeneration = 10;
    private const int MaxEndurance = 100;

    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        Name = name;
        Age = age;
        Experience = experience;
        Endurance = endurance;

        this.Weapons = new Dictionary<string, IAmmunition>();
    }

    public IDictionary<string, IAmmunition> Weapons { get; }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get { return this.endurance; }
        protected set
        {
            this.endurance = Math.Min(value, MaxEndurance);
        }
    }

    public virtual double OverallSkill => this.Age + this.Experience;

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    public virtual void Regenerate()
    {
        this.Endurance += this.Age + InitialRegeneration;
    }

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= 100;
    }
}