namespace Collector
{
    using High_Quality_Mistakes.Models;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var spy = new Spy();
            var result = spy.CollectGettersAndSetters("Hacker");
            Console.WriteLine(result);
        }
    }
}
