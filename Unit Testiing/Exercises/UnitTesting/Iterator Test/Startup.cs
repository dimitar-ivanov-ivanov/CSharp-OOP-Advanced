namespace Iterator_Test
{
    using Iterator_Test.Core;
    using Iterator_Test.Models;
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
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var listyIterator = new ListIterator(args.Skip(1).ToArray());

            var engine = new Engine(listyIterator);
            engine.Run();
        }
    }
}