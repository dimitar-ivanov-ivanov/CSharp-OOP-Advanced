using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture]
public class InventoryTests
{
    private IInventory inventory;

    [SetUp]
    public void TestInit()
    {
        this.inventory = new HeroInventory();
    }

    [Test]
    public void InvertoryAddsItem()
    {
        var item = new CommonItem("Shield", 10, 10, 10, 10, 10);

        inventory.AddCommonItem(item);

        var itemField = this.inventory.GetType()
            .GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .FirstOrDefault(x => x.Name == "commonItems");

        var commonItems = (Dictionary<string, IItem>)itemField.GetValue(inventory);

        Assert.AreEqual(commonItems.Count, 1);
    }

    [Test]
    public void InvertoryAddsRecipe()
    {
        var item = new RecipeItem("Shield", 10, 10, 10, 10, 10, new List<string>() { "Helmet" });

        inventory.AddRecipeItem(item);

        var itemField = this.inventory.GetType()
            .GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .FirstOrDefault(x => x.Name == "recipeItems");

        var recipeItems = (Dictionary<string, IRecipe>)itemField.GetValue(inventory);

        Assert.AreEqual(recipeItems.Count, 1);
    }

    [Test]
    public void InvertoryTotalStrenghtBonusCheck()
    {
        var item = new CommonItem("Shield", 10, 0, 0, 0, 0);

        inventory.AddCommonItem(item);

        Assert.AreEqual(item.StrengthBonus, 10);
    }

    [Test]
    public void InvertoryTotalAgilityBonusCheck()
    {
        var item = new CommonItem("Shield", 0, 10, 0, 0, 0);

        inventory.AddCommonItem(item);

        Assert.AreEqual(item.AgilityBonus, 10);
    }

    [Test]
    public void InvertoryTotalIntelligenceBonusCheck()
    {
        var item = new CommonItem("Shield", 0, 0, 10, 0, 0);

        inventory.AddCommonItem(item);

        Assert.AreEqual(item.IntelligenceBonus, 10);
    }

    [Test]
    public void InvertoryTotalHitPointsBonusCheck()
    {
        var item = new CommonItem("Shield", 0, 0, 0, 10, 0);

        inventory.AddCommonItem(item);

        Assert.AreEqual(item.HitPointsBonus, 10);
    }

    [Test]
    public void InvertoryTotalDamageBonusCheck()
    {
        var item = new CommonItem("Shield", 0, 0, 0, 0, 10);

        inventory.AddCommonItem(item);

        Assert.AreEqual(item.DamageBonus, 10);
    }
}