namespace Event_Implementation
{
    using Event_Implementation.Models;
    using System;
    
    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();

            dispatcher.NameChange += handler.OnDispatcherNameChange;

            var engine = new Engine(dispatcher);
            engine.Run();
        }
    }
}