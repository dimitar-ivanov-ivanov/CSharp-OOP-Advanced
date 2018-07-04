namespace CardGame
{
    using CardGame.Models;
    using CardPower.Models;
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var players = new Dictionary<string, HashSet<Card>>();
            var player1 = Console.ReadLine();
            var player2 = Console.ReadLine();
            var game = new Game(player1, player2);

            while (true)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (game.AddCard(args[0], args[2]))
                    {
                        break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(game.FindWinner());
        }
    }
}