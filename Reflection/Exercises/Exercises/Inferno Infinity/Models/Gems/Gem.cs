namespace Inferno_Infinity.Models.Gems
{
    using Inferno_Infinity.Contracts;
    using Inferno_Infinity.Enums;
    using System;

    public abstract class Gem : IGem
    {
        private int strength;
        private int agility;
        private int vitality;
        private GemClarity gemClarity;

        public static int StrengthMinDamageMultiplier = 2;
        public static int StrengthMaxDamageMultiplier = 3;
        public static int AgilitythMinDamageMultiplier = 1;
        public static int AgilitythMaxDamageMultiplier = 4;

        public Gem(int strength, int agility, int vitality, GemClarity gemClarity)
        {
            this.strength = strength;
            this.agility = agility;
            this.vitality = vitality;
            this.gemClarity = gemClarity;
        }

        public int Strength { get => strength; private set => strength = value; }

        public int Agility { get => agility; private set => agility = value; }

        public int Vitality { get => vitality; private set => vitality = value; }

        public GemClarity GemClarity { get => gemClarity; private set => gemClarity = value; }

        public IGem CalculatedActivatedClarity()
        {
            var currentType = this.GetType();
            var newStrength = this.strength + (int)this.GemClarity;
            var newAgility = this.agility + (int)this.GemClarity;
            var newVitality = this.vitality + (int)this.GemClarity;

            return (IGem)Activator.CreateInstance(currentType, new object[]
                         {newStrength,newAgility,newVitality,this.GemClarity });
        }
    }
}
