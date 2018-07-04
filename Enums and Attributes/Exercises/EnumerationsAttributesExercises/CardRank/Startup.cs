namespace CreateCardRank
{
    using CreateCardRank.Enums;
    using System;

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

            for (int i = 0; i < 13; i++)
            {
                var cardRank = (CardRank)i;
                Console.WriteLine($"Ordinal value: {i}; Name value: {cardRank}");
            }
        }
    }
}
