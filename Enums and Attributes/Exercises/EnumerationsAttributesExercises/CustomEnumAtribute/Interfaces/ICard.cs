namespace CardPower.Interfaces
{
    using CreateCardRank.Enums;
    using CreateCardSuit.Enums;

    public interface ICard
    {
        CardSuit CardSuit { get; }

        CardRank CardRank { get; }
    }
}
