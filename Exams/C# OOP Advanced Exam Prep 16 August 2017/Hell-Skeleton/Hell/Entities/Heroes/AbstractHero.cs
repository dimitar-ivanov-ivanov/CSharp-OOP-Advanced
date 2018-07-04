using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public abstract class AbstractHero : IHero
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name, long strength, long agility, long intelligence,
        long hitPoints, long damage)
    {
        this.Name = name;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.hitPoints = hitPoints;
        this.damage = damage;
        this.inventory = new HeroInventory();
    }

    public string Name { get; }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.HitPoints + this.Damage; }
    }

    public ICollection<IItem> Items
    {
        get
        {
            var itemsFields = inventory.GetType()
                    .GetFields(BindingFlags.Public | BindingFlags.NonPublic |
                               BindingFlags.Static | BindingFlags.Instance)
                     .Where(x => x.GetCustomAttribute<ItemAttribute>() != null)
                     .FirstOrDefault();

            var items = (Dictionary<string, IItem>)itemsFields.GetValue(this.inventory);

            return items.Values.ToList();
        }
    }

    public void AddItem(IItem item)
    {
        this.inventory.AddCommonItem(item);
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}");
        builder.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        builder.AppendLine($"Strength: {this.Strength}");
        builder.AppendLine($"Agility: {this.Agility}");
        builder.AppendLine($"Intelligence: {this.Intelligence}");

        if(this.Items.Count == 0)
        {
            builder.AppendLine("Items: None");
        }
        else
        {
            builder.AppendLine("Items:");

            foreach (var item in this.Items)
            {
                builder.AppendLine(item.ToString());
            }
        }

        return builder.ToString().TrimEnd();
    }
}