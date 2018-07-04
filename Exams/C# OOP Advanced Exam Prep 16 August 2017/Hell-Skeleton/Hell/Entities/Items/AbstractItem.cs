public abstract class AbstractItem : IItem
{
    protected AbstractItem(string name, long strengthBonus, long agilityBonus,
        long intelligenceBonus, long hitPointsBonus, long damageBonus)
    {
        Name = name;
        StrengthBonus = strengthBonus;
        AgilityBonus = agilityBonus;
        IntelligenceBonus = intelligenceBonus;
        HitPointsBonus = hitPointsBonus;
        DamageBonus = damageBonus;
    }

    public string Name { get; }

    public long StrengthBonus { get; }

    public long AgilityBonus { get; }

    public long IntelligenceBonus { get; }

    public long HitPointsBonus { get; }

    public long DamageBonus { get; }

    public override string ToString()
    {
        return $"###Item: {this.Name}\n" + 
               $"###+{this.StrengthBonus} Strength\n" + 
               $"###+{this.AgilityBonus} Agility\n" + 
               $"###+{this.IntelligenceBonus} Intelligence\n" + 
               $"###+{this.HitPointsBonus} HitPoints\n" + 
               $"###+{this.DamageBonus} Damage";
    }
}