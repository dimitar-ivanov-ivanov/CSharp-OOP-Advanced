namespace Inferno_Infinity.Models.Weapons
{
    using Inferno_Infinity.Attributes;
    using Inferno_Infinity.Enums;

    [Weapon("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.",
        new string[] { "Pesho", "Svetlio" })]
    public class Sword : Weapon
    {
        private const int MinSwordDamage = 4;
        private const int MaxSwordDamage = 6;
        private const int SocketLength = 3;

        public Sword(string name, ItemRarity rarity)
          : this(name, MaxSwordDamage, MinSwordDamage, SocketLength, rarity) { }

        public Sword(string name, int maxDamage, int minDamage, int socketLength, ItemRarity rarity)
            : base(name, maxDamage, minDamage, socketLength, rarity)
        {
        }
    }
}
