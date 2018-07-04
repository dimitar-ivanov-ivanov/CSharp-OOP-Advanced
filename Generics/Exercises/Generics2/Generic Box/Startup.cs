namespace Generic_Box
{
    using Generic_Box.Models;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var input = Console.ReadLine();
            var box = new Box<string>(input);
            Console.WriteLine(box);
        }
    }
}