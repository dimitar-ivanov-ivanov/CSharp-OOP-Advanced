namespace Traffic_Lights
{
    using System;
    using System.Linq;
    using Traffic_Lights.Enums;
    using Traffic_Lights.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var args = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => (TrafficLights)Enum.Parse(typeof(TrafficLights), x))
                .ToArray();

            var trafficStop = new TrafficStop(args);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                trafficStop.TurnLights();
                Console.WriteLine();
            }
        }
    }
}
