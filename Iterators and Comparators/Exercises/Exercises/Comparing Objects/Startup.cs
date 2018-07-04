namespace Comparing_Objects
{
    using Comparing_Objects.Contracts;
    using Comparing_Objects.Models;
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
            var people = GetPeople();
            GetMatches(people);
        }

        private static void GetMatches(IList<IPerson> people)
        {
            var n = int.Parse(Console.ReadLine()) - 1;
            var equal = 0;

            foreach (var person in people)
            {
                if (person.Equals(people[n]))
                {
                    equal++;
                }
            }

            if (equal == 1)
            {
                Console.WriteLine($"No matches");
            }
            else
            {
                Console.WriteLine($"{equal} {people.Count - equal} {people.Count}");
            }
        }

        private static IList<IPerson> GetPeople()
        {
            var people = new List<IPerson>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                people.Add(new Person(args[0], int.Parse(args[1]), args[2]));

                input = Console.ReadLine();
            }

            return people;
        }
    }
}