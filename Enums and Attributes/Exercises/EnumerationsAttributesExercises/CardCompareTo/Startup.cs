namespace CardCompareTo
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
            var card1 = new Card(rank, suit);

            rank = Console.ReadLine();
            suit = Console.ReadLine();
            var card2 = new Card(rank, suit);

            if(card1.CompareTo(card2) == 1)
            {
                Console.WriteLine(card1);
            }
            else
            {
                Console.WriteLine(card2);
            }
        }
    }
}
