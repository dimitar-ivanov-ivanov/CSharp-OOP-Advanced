namespace Create_Logger.Contracts
{
    using Create_Logger.Enums;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string appenderName,ILayout layout, ReportLevel reportLevel);
    }
}
