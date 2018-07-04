namespace CustomEnumAtribute
{
    using CreateCardRank.Enums;
    using CreateCardSuit.Enums;
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
            var enumType = line == "Suit" ? typeof(CardSuit) :
                typeof(CardRank);
            
            var attrs = enumType.GetCustomAttributes(false);
            Console.WriteLine(string.Join("\n", attrs));
        }
    }
}
