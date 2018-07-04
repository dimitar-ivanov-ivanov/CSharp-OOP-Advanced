namespace Create_Logger.Factories
{
    using Create_Logger.Contracts;
    using Create_Logger.Enums;
    using Create_Logger.Models.Appenders;
    using Create_Logger.Models.Logs;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string appenderName, ILayout layout, ReportLevel reportLevel)
        {
            switch (appenderName)
            {
                case "ConsoleAppender":
                    return new ConsoleAppender(layout, reportLevel);
                case "FileAppender":
                    return new FileAppender(layout, new LogFile(), reportLevel);
                default:
                    break;
            }

            return null;
        }
    }
}
