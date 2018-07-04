namespace Black_Box_Integer
{
    using Black_Box_Integer.Core;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var engine = new Engine();
            engine.Run();
        }
    }
}