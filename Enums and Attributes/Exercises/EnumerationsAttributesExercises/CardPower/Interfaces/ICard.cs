using CreateCardRank.Enums;
using CreateCardSuit.Enums;

namespace CardPower.Interfaces
{
    public interface ICard
    {
        CardSuit CardSuit { get; }

        CardRank CardRank { get; }
    }
}
