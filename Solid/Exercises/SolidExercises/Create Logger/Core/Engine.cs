namespace Create_Logger.Core
{
    using Create_Logger.Contracts;
    using System;

    public class Engine : IEngine
    {
        private ILogger logger;
        private const string TerminatingCommand = "END";

        public Engine(ILogger logger)
        {
            this.Logger = logger;
        }

        public ILogger Logger
        {
            get { return this.logger; }
            private set { this.logger = value; }
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != TerminatingCommand)
            {
                var args = SplitByChar(input, '|');

                var command = args[0];
                var dateTime = args[1];
                var message = args[2];

                switch (command)
                {
                    case "INFO":
                        Logger.Info(dateTime, message);
                        break;
                    case "WARNING":
                        Logger.Warn(dateTime, message);
                        break;
                    case "ERROR":
                        Logger.Error(dateTime, message);
                        break;
                    case "CRITICAL":
                        Logger.Critical(dateTime, message);
                        break;
                    case "FATAL":
                        Logger.Fatal(dateTime, message);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.Write(logger);
        }

        private string[] SplitByChar(string input, params char[] delimeters)
        {
            return input.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
