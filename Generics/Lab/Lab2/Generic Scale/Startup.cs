namespace Generic_Scale
{
    using System;
    using Generic_Scale.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var scale = new Scale<int>(1, 2);
            Console.WriteLine(scale.GetHavier());

            scale = new Scale<int>(2, 1);
            Console.WriteLine(scale.GetHavier());

            scale = new Scale<int>(1, 1);
            Console.WriteLine(scale.GetHavier());
        }
    }
}