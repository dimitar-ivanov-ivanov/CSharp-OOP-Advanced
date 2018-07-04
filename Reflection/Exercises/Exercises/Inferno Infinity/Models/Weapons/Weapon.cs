namespace Inferno_Infinity.Models.Weapons
{
    using Inferno_Infinity.Attributes;
    using Inferno_Infinity.Contracts;
    using Inferno_Infinity.Enums;
    using Inferno_Infinity.Models.Gems;
    using System;
    using System.Linq;

    [Weapon("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.",
        new string[] { "Pesho", "Svetlio" })]
    public abstract class Weapon : IWeapon
    {
        private int maxDamage;
        private int minDamage;
        private IGem[] sockets;
        private ItemRarity rarity;
        private string name;

        public Weapon(string name, int maxDamage, int minDamage,
            int socketLength, ItemRarity rarity)
        {
            this.name = name;
            this.maxDamage = maxDamage;
            this.minDamage = minDamage;
            this.sockets = new IGem[socketLength];
            this.rarity = rarity;
        }

        public int MaxDamage
        {
            get { return this.maxDamage; }
            private set { this.maxDamage = value; }
        }

        public int MinDamage
        {
            get { return this.minDamage; }
            private set { this.minDamage = value; }
        }

        public IGem[] Sockets
        {
            get { return this.sockets; }
            private set { this.sockets = value; }
        }

        public ItemRarity Rarity
        {
            get { return this.rarity; }
            private set { this.rarity = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public IWeapon CalculatedActivatedClarity()
        {
            var currentType = this.GetType();
            var newMinDamage = this.MinDamage * (int)this.Rarity;
            var newMaxDamage = this.MaxDamage * (int)this.Rarity;

            return (IWeapon)Activator.CreateInstance(currentType,
                          new object[] { newMaxDamage, newMaxDamage, this.Rarity });
        }

        public string Print()
        {
            var improvedSockets = this.sockets
                .Where(x => x != null)
                .Select(x => x.CalculatedActivatedClarity())
                .ToArray();

            var totalStrength = improvedSockets.Sum(x => x.Strength);
            var totalAgility = improvedSockets.Sum(x => x.Agility);
            var totalVitality = improvedSockets.Sum(x => x.Vitality);

            var outputMinDamage = (int)rarity * this.MinDamage;
            var outputMaxDamage = (int)rarity * this.MaxDamage;

            foreach (var socket in improvedSockets)
            {
                outputMinDamage += socket.Strength * Gem.StrengthMinDamageMultiplier;
                outputMinDamage += socket.Agility * Gem.AgilitythMinDamageMultiplier;

                outputMaxDamage += socket.Strength * Gem.StrengthMaxDamageMultiplier;
                outputMaxDamage += socket.Agility * Gem.AgilitythMaxDamageMultiplier;
            }

            return $"{this.Name}: {outputMinDamage}-{outputMaxDamage} Damage, +{totalStrength} Strength, +{totalAgility} Agility, +{totalVitality} Vitality";
        }
    }
}
