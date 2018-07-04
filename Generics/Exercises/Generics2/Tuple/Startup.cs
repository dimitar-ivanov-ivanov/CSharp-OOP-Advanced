namespace Tuple
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
            var args = Console.ReadLine().Split(' ');
            var fullName = args[0] + " " + args[1];
            var address = args[2];

            var tuple = new Models.Tuple<string, string>(fullName, address);
            Console.WriteLine(tuple);

            args = Console.ReadLine().Split(' ');
            var name = args[0];
            var beer = int.Parse(args[1]);

            var tuple1 = new Models.Tuple<string, int>(name, beer);
            Console.WriteLine(tuple1);

            args = Console.ReadLine().Split(' ');
            var value1 = int.Parse(args[0]);
            var value2 = double.Parse(args[1]);
            var tuple2 = new Models.Tuple<int, double>(value1, value2);

            Console.WriteLine(tuple2);
        }
    }
}
