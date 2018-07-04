namespace Dependency_Inversion
{
    using Dependency_Inversion.Models;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var primitiveCalculator = new PrimitiveCalculator();

            while (args[0] != "End")
            {
                switch (args[0])
                {
                    case "mode":
                        primitiveCalculator.changeStrategy(args[1][0]);
                        break;
                    default:
                        var first = int.Parse(args[0]);
                        var second = int.Parse(args[1]);
                        var res = primitiveCalculator.performCalculation(first, second);
                        Console.WriteLine(res);
                        break;
                }

                args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

        }
    }
}