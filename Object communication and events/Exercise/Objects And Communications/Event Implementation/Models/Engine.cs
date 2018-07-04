namespace Event_Implementation.Models
{
    using System;

    public class Engine
    {
        private Dispatcher dispatcher;

        public Engine(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        private const string TerminatingCommand = "End";

        public void Run()
        {
            var input = Console.ReadLine();

            while(input != TerminatingCommand)
            {
                dispatcher.OnNameChange(new NameChangeEventArgs(input));
                input = Console.ReadLine();
            }
        }
    }
}
