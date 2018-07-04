namespace Inferno_Infinity.Models.Gems
{
    using Inferno_Infinity.Enums;

    public class Emerald : Gem
    {
        private const int EmeraldStrength = 1;
        private const int EmeraldAgility = 4;
        private const int EmeraldVitality = 9;

        public Emerald(int strength, int agility, int vitality, GemClarity gemClarity) : base(strength, agility, vitality, gemClarity)
        {
        }

        public Emerald(GemClarity gemClarity)
          : this(EmeraldStrength, EmeraldAgility, EmeraldVitality, gemClarity) { }
    }
}
