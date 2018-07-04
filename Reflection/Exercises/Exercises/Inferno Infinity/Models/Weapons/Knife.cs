namespace Inferno_Infinity.Models.Weapons
{
    using Inferno_Infinity.Attributes;
    using Inferno_Infinity.Enums;

    [Weapon("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.",
        new string[] { "Pesho", "Svetlio" })]
    public class Knife : Weapon
    {
        private const int MinKnifeDamage = 3;
        private const int MaxKnifeDamage = 4;
        private const int SocketLength = 2;

        public Knife(string name, ItemRarity rarity)
            : this(name, MaxKnifeDamage, MinKnifeDamage, SocketLength, rarity) { }

        protected Knife(string name, int maxDamage, int minDamage, int socketLength, ItemRarity rarity) 
            : base(name, maxDamage, minDamage, socketLength, rarity)
        {
        }
    }
}
