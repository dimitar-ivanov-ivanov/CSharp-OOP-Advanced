namespace Equality_Logic
{
    using Equality_Logic.Models;
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
            var hash = new HashSet<Person>();
            var tree = new SortedSet<Person>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var person = new Person(args[0], int.Parse(args[1]));

                hash.Add(person);
                tree.Add(person);
            }

            Console.WriteLine(tree.Count);
            Console.WriteLine(hash.Count);
        }
    }
}