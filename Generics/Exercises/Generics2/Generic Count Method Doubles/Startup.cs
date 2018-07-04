namespace Generic_Count_Method_Doubles
{
    using Generic_Box.Models;
    using Generic_Count_Method_Strings.Models;
    using System;
    using System.Collections.Generic;
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
            var n = int.Parse(Console.ReadLine());
            var list = new List<Box<double>>();

            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                var box = new Box<double>(input);
                list.Add(box);
            }

            var valueToCompare = double.Parse(Console.ReadLine());
            var boxToCompare = new Box<double>(valueToCompare);
            var countBigger = CountValues.CountValuesGreaterThan(list, boxToCompare);

            Console.WriteLine(countBigger);
        }
    }
}
