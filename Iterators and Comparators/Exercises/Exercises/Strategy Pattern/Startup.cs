namespace Strategy_Pattern
{
    using Comparing_Objects.Models;
    using Strategy_Pattern.Models;
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
            var nameSorter = new SortedSet<Person>(new PersonLengthComparer());
            var ageSorter = new SortedSet<Person>(new AgeComparer());

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var person = new Person(args[0], int.Parse(args[1]));
                nameSorter.Add(person);
                ageSorter.Add(person);
            }

            Console.WriteLine(string.Join("\n",nameSorter));
            Console.WriteLine(string.Join("\n", ageSorter));
        }
    }
}