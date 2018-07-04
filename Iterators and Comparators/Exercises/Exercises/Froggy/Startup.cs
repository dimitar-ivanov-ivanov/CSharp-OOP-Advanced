namespace Froggy
{
    using Froggy.Models;
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var lake = new Lake<int>(args.Select(int.Parse).ToList());
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
