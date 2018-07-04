using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IManager
{
    private IDictionary<string, IHero> heroes;
    private IHeroFactory heroFactory;
    private IItemFactory itemFactory;

    public HeroManager(IHeroFactory heroFactory, IItemFactory itemFactory)
    {
        this.heroes = new Dictionary<string, IHero>();
        this.heroFactory = heroFactory;
        this.itemFactory = itemFactory;
    }

    public string AddHero(IList<string> arguments)
    {
        var hero = heroFactory.CreateHero(arguments);

        if (!this.heroes.ContainsKey(hero.Name))
        {
            this.heroes.Add(hero.Name, hero);
        }

        return string.Format(Constants.HeroCreateMessage, hero.GetType().Name, hero.Name);
    }

    public string AddItemToHero(IList<string> arguments)
    {
        var heroName = arguments[2];
        arguments.RemoveAt(2);

        var newItem = itemFactory.CreateItem(arguments);
        this.heroes[heroName].AddItem(newItem);

        return string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
    }

    public string Inspect(IList<string> arguments)
    {
        string heroName = arguments[1];

        return this.heroes[heroName].ToString();
    }

    public string AddRecipeToHero(IList<string> arguments)
    {
        var heroName = arguments[2];
        arguments.RemoveAt(2);

        var newRecipe = (IRecipe)itemFactory.CreateItem(arguments);
        this.heroes[heroName].AddRecipe(newRecipe);

        return string.Format(Constants.RecipeCreatedMessage, newRecipe.Name, heroName);
    }

    public string Quit()
    {
        var builder = new StringBuilder();

        var ordered = this.heroes
            .OrderByDescending(x => x.Value.PrimaryStats)
            .ThenByDescending(x => x.Value.SecondaryStats)
            .ToDictionary(x => x.Key, x => x.Value);

        var count = 1;

        foreach (var hero in ordered.Values)
        {
            builder.AppendLine($"{count++}. {hero.GetType().Name}: {hero.Name}");
            builder.AppendLine($"###HitPoints: {hero.HitPoints}");
            builder.AppendLine($"###Damage: {hero.Damage}");
            builder.AppendLine($"###Strength: {hero.Strength}");
            builder.AppendLine($"###Agility: {hero.Agility}");
            builder.AppendLine($"###Intelligence: {hero.Intelligence}");

            var items = hero.Items.Select(x => x.Name).ToArray();

            if (items.Length == 0)
            {
                builder.AppendLine("###Items: None");
            }
            else
            {
                var str = string.Join(", ", items);
                builder.AppendLine($"###Items: {str}");
            }
        }

        return builder.ToString().TrimEnd();
    }
}