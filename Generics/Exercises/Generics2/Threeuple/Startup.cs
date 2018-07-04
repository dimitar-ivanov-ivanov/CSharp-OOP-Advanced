namespace Threeuple
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Execute();
        }

        private static void Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = args[0] + " " + args[1];
            var adress = args[2];
            var town = args[3];

            var threeuple = new Models.Threeuple<string, string, string>(name, adress, town);

            Console.WriteLine(threeuple);

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            name = args[0];
            var beer = int.Parse(args[1]);
            var drunkOrNot = args[2].Equals("drunk", StringComparison.OrdinalIgnoreCase);

            var threeuple1 = new Models.Threeuple<string, int, bool>(name, beer, drunkOrNot);

            Console.WriteLine(threeuple1);

            args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            name = args[0];
            var accountBalance = double.Parse(args[1]);
            var bankName = args[2];

            var threeuple2 = new Models.Threeuple<string, double, string>(name, accountBalance, bankName);

            Console.WriteLine(threeuple2);

        }
    }
}