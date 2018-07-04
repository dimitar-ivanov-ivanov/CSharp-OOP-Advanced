namespace DeckOfCards
{
    using CreateCardRank.Enums;
    using CreateCardSuit.Enums;
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var line = Console.ReadLine();
            var output = new StringBuilder();

            for (int i = 0; i < 13; i++)
            {
                var rank = (CardRank)i;
                for (int j = 0; j < 4; j++)
                {
                    var suit = (CardSuit)j;
                    output.AppendLine($"{rank} of {suit}");
                }
            }

            Console.Write(output);
        }
    }
}
