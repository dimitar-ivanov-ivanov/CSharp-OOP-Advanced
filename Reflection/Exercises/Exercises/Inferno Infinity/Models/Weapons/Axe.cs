namespace Inferno_Infinity.Models.Weapons
{
    using Inferno_Infinity.Attributes;
    using Inferno_Infinity.Enums;

    [Weapon("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.",
        new string[] { "Pesho", "Svetlio" })]
    public class Axe : Weapon
    {
        private const int MinAxeDamage = 5;
        private const int MaxAxeDamage = 10;
        private const int SocketLength = 4;

        public Axe(string name, ItemRarity rarity)
          : this(name, MaxAxeDamage, MinAxeDamage, SocketLength, rarity) { }

        protected Axe(string name, int maxDamage, int minDamage, int socketLength, ItemRarity rarity)
            : base(name, maxDamage, minDamage, socketLength, rarity)
        {
        }
    }
}
