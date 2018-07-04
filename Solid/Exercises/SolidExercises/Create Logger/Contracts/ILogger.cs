namespace Create_Logger.Contracts
{
    using System.Collections.Generic;

    public interface ILogger
    {
        IList<IAppender> Appenders { get; }

        void Info(string dateTime, string message);

        void Warn(string dateTime, string message);

        void Error(string dateTime, string message);

        void Critical(string dateTime, string message);

        void Fatal(string dateTime, string message);

    }
}
