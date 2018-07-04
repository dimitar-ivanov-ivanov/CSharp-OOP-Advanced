namespace CardGame.Models
{
    using CardPower.Models;
    using CreateCardRank.Enums;
    using CreateCardSuit.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Game
    {
        private List<KeyValuePair<string, HashSet<Card>>> players;
        private List<string> playerNames;
        private int currentIndex;

        public Game(string player1, string player2)
        {
            playerNames = new List<string>();
            players = new List<KeyValuePair<string, HashSet<Card>>>();
            players.Add(new KeyValuePair<string, HashSet<Card>>(player1, new HashSet<Card>()));
            players.Add(new KeyValuePair<string, HashSet<Card>>(player2, new HashSet<Card>()));

            playerNames.Add(player1);
            playerNames.Add(player2);
            currentIndex = 0;
        }

        public bool AddCard(string rank, string suit)
        {
            CardSuit cardSuit;
            CardRank cardRank;

            if (Enum.TryParse(suit, out cardSuit) &&
                Enum.TryParse(rank, out cardRank))
            {
                var card = new Card(rank, suit);
                if (!players[currentIndex].Value.Contains(card))
                {
                    players[currentIndex].Value.Add(card);
                    if (players[currentIndex].Value.Count == 5)
                    {
                        currentIndex++;
                    }
                    if (currentIndex == 2)
                    {
                        return true;
                    }
                }
                else
                {
                    throw new ArgumentException("Card is not in the deck.");
                }
            }
            else
            {
                throw new ArgumentException("No such card exists.");
            }

            return false;
        }

        public string FindWinner()
        {
            var topPlayer = players
               .OrderByDescending(x => x.Value.Max(y => y.Rank))
              .FirstOrDefault();

            var topCard = topPlayer.Value
                .OrderByDescending(x => x).FirstOrDefault();
            return $"{topPlayer.Key} wins with {topCard}.";
        }
    }
}
