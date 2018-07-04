namespace Generic_Swap_Method_Integers
{
    using Generic_Box.Models;
    using Generic_Swap_Method_Strings.Models;
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
            var list = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                var box = new Box<int>(input);
                list.Add(box);
            }

            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var index = int.Parse(args[0]);
            var index1 = int.Parse(args[1]);
            SwapValues.Swap(list, index, index1);

            foreach (var box in list)
            {
                Console.WriteLine(box.ToString());
            }
        }
    }
}