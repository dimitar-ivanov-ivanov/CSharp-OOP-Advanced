namespace Inferno_Infinity.Models.Gems
{
    using Inferno_Infinity.Enums;

    public class Amethyst : Gem
    {
        private const int AmethystStrength = 2;
        private const int AmethystAgility = 8;
        private const int AmethystVitality = 4;

        public Amethyst(int strength, int agility, int vitality, GemClarity gemClarity)
            : base(strength, agility, vitality, gemClarity)
        {
        }

        public Amethyst(GemClarity gemClarity)
            : this(AmethystStrength, AmethystAgility, AmethystVitality, gemClarity) { }
    }
}
