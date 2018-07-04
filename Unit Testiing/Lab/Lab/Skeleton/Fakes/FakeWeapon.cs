using System;

public class FakeWeapon : IWeapon
{
    private int attackPoints;
    private int durabilityPoints = 20;

    public int AttackPoints => 20;

    public int DurabilityPoints
    {
        get { return this.durabilityPoints; }
        private set { this.durabilityPoints = value; }
    }

    public void Attack(ITarget target)
    {
        if (this.DurabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(this.AttackPoints);
        this.DurabilityPoints -= 1;
    }
}
