namespace CreateCardSuit
{
    using System;
    using CreateCardSuit.Enums;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var line = Console.ReadLine();
            Console.WriteLine(line + ":");

            for (int i = 0; i < 4; i++)
            {
                var cardSuit = (CardSuit)Enum.ToObject(typeof(CardSuit), i);
                Console.WriteLine($"Ordinal value: {i}; Name value: {cardSuit}");
            }
        }
    }
}