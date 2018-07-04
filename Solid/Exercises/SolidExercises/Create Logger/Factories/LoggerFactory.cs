namespace Create_Logger.Factories
{
    using Create_Logger.Contracts;
    using Create_Logger.Enums;
    using Create_Logger.Models.Loggers;
    using System;

    public class LoggerFactory : ILoggerFactory
    {
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        public LoggerFactory(IAppenderFactory appenderFactory, ILayoutFactory layoutFactory)
        {
            this.appenderFactory = appenderFactory;
            this.layoutFactory = layoutFactory;
        }

        public IAppenderFactory AppenderFactory { get => appenderFactory; private set => appenderFactory = value; }
        public ILayoutFactory LayoutFactory { get => layoutFactory; private set => layoutFactory = value; }

        public ILogger CreateLogger()
        {
            var n = int.Parse(Console.ReadLine());
            var appenders = new IAppender[n];

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var appenderName = args[0];
                var layoutName = args[1];

                var reportLevel = ReportLevel.INFO;

                if (args.Length > 2)
                {
                    reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), args[2]);
                }

                var layout = LayoutFactory.CreateLayout(layoutName);

                appenders[i] = AppenderFactory.CreateAppender(appenderName, layout, reportLevel);
            }

            return new Logger(appenders);
        }
    }
}
