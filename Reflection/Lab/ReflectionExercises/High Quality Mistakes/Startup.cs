namespace High_Quality_Mistakes
{
    using High_Quality_Mistakes.Models;
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        public static void Execute()
        {
            var spy = new Spy();
            var result = spy.AnalyzeAcessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}