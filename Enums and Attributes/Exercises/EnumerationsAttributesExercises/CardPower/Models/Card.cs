using CardPower.Interfaces;
using CreateCardRank.Enums;
using CreateCardSuit.Enums;
using System;

namespace CardPower.Models
{
    public class Card : ICard
    {
        private CardRank cardRank;
        private CardSuit cardSuit;
        private int rank;

        public CardRank CardRank => cardRank;
        public CardSuit CardSuit => cardSuit;

        public Card(string cardRank,string cardSuit)
        {
            Enum.TryParse(cardRank,out this.cardRank);
            Enum.TryParse(cardSuit, out this.cardSuit);
            this.rank = (int)CardRank + (int)CardSuit;
        }

        public override string ToString()
        {
            return $"Card name: {this.CardRank} of {this.CardSuit}; Card power: {this.rank}";
        }
    }
}
