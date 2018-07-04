namespace Inferno_Infinity.Contracts
{
    using Inferno_Infinity.Enums;

    public interface IWeapon
    {
        string Name { get; }

        int MaxDamage { get; }

        int MinDamage { get; }

        IGem[] Sockets { get; }

        ItemRarity Rarity { get; }

        string Print();
    }
}
