namespace Create_Logger.Models.Loggers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Create_Logger.Contracts;

    public class Logger : ILogger
    {
        private IList<IAppender> appenders;

        public IList<IAppender> Appenders
        {
            get { return this.appenders; }
            private set { this.appenders = value; }
        }

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders.ToList();
        }

        public void Info(string dateTime, string message)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(dateTime, "INFO", message);
            }
        }

        public void Warn(string dateTime, string message)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(dateTime, "WARNING", message);
            }
        }

        public void Error(string dateTime, string message)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(dateTime, "ERROR", message);
            }
        }

        public void Critical(string dateTime, string message)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(dateTime, "CRITICAL", message);
            }
        }

        public void Fatal(string dateTime, string message)
        {
            foreach (var appender in this.appenders)
            {
                appender.Append(dateTime, "FATAL", message);
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendLine("Logger info");

            foreach (var appender in this.Appenders)
            {
                output.AppendLine(appender.ToString());
            }

            return output.ToString();
        }
    }
}
