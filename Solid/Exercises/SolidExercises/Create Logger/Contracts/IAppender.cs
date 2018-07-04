namespace Create_Logger.Contracts
{
    using Create_Logger.Enums;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; }

        int Count { get; }

        void Append(string dateTime, string reportLevel, string message);

        bool ReadyToAppend(string reportLevel);
    }
}
