namespace Generic_Box_of_String
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
            var n = int.Parse(Console.ReadLine());
           
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var box = new Box<string>(input);
                Console.WriteLine(box);
            }   
        }
    }
}
