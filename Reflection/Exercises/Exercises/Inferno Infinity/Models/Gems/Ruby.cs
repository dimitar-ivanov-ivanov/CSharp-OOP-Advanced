namespace Inferno_Infinity.Models.Gems
{
    using Inferno_Infinity.Enums;

    public class Ruby : Gem
    {
        private const int RubyStrength = 7;
        private const int RubyAgility = 2;
        private const int RubyVitality = 5;

        public Ruby(int strength, int agility, int vitality, GemClarity gemClarity) 
            : base(strength, agility, vitality, gemClarity)
        {
        }

        public Ruby(GemClarity gemClarity)
            : this(RubyStrength, RubyAgility, RubyVitality, gemClarity) { }
    }
}
