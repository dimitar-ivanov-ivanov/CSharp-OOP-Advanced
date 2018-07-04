namespace Stealer
{
    using Stealer.Models;
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
            var result = spy.StealMethodInfo("Hacker", "username", "password");
            Console.WriteLine(result);
        }
    }
}
