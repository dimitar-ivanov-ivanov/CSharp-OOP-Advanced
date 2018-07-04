namespace TrafficLights
{
    using System;
    using System.Collections.Generic;
    using TrafficLights.Enums;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var trafficLights = new List<TrafficLight>();

            for (int i = 0; i < args.Length; i++)
            {
                var trafficLight = new TrafficLight(args[i]);
                trafficLights.Add(trafficLight);
            }

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < trafficLights.Count; j++)
                {
                    trafficLights[j].UpdateState();
                    Console.Write(trafficLights[j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
