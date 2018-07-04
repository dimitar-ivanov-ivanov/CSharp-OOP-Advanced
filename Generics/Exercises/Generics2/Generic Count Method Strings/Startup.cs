namespace Generic_Count_Method_Strings
{
    using Generic_Box.Models;
    using Generic_Count_Method_Strings.Models;
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
            var n = int.Parse(Console.ReadLine());
            var list = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var box = new Box<string>(input);
                list.Add(box);
            }

            var valueToCompare = Console.ReadLine();
            var boxToCompare = new Box<string>(valueToCompare);
            var countBigger = CountValues.CountValuesGreaterThan(list,boxToCompare);

            Console.WriteLine(countBigger);
        }
    }
}
