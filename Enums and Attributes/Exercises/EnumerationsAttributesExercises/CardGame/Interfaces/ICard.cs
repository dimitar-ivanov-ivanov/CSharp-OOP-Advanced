namespace CardPower.Interfaces
{
    using CreateCardRank.Enums;
    using CreateCardSuit.Enums;
    using System;

    public interface ICard : IComparable<ICard>
    {
        CardSuit CardSuit { get; }

        CardRank CardRank { get; }

        int Rank { get; }
    }
}
