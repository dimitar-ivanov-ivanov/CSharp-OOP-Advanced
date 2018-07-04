namespace CardPower.Models
{
    using CardPower.Interfaces;
    using CreateCardRank.Enums;
    using CreateCardSuit.Enums;
    using System;

    public class Card : ICard
    {
        private CardRank cardRank;
        private CardSuit cardSuit;
        private int rank;

        public CardRank CardRank => this.cardRank;
        public CardSuit CardSuit => this.cardSuit;

        public int Rank => this.rank;

        public Card(string cardRank, string cardSuit)
        {
            Enum.TryParse(cardRank, out this.cardRank);
            Enum.TryParse(cardSuit, out this.cardSuit);
            this.rank = (int)CardRank + (int)CardSuit;
        }

        public override string ToString()
        {
            return $"{this.CardRank} of {this.CardSuit}";
        }

        public int CompareTo(ICard other)
        {
            return this.Rank.CompareTo(other.Rank);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var otherCard = obj as Card;
            return this.CardRank == otherCard.CardRank &&
                   this.CardSuit == otherCard.CardSuit;
        }
    }
}
