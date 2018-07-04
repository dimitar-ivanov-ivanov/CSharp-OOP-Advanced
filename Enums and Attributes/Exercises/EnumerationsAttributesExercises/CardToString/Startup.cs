namespace CardToString
{
    using CardPower.Models;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var rank = Console.ReadLine();
            var suit = Console.ReadLine();
            var card = new Card(rank, suit);
            Console.WriteLine(card);
        }
    }
}
