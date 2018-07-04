using System.Collections.Generic;
using System.Text;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplier = 3.5;
    private const double RegenerationIncrease = 20;
    private readonly List<string> weaponsAllowed = new List<string>
        {
        nameof(Gun),
        nameof(AutomaticMachine),
        nameof(MachineGun),
        nameof(RPG),
        nameof(Helmet),
        nameof(Knife),
        nameof(NightVision)
        };

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }

    protected override IReadOnlyList<string> WeaponsAllowed => (IReadOnlyList<string>)weaponsAllowed;

    public override double OverallSkill => base.OverallSkill * OverallSkillMiltiplier;

    public override void Regenerate()
    {
        base.Regenerate();
        this.Endurance += RegenerationIncrease;
    }
}