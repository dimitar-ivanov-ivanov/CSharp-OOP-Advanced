namespace Create_Logger.Contracts
{
    public interface ILoggerFactory
    {
        IAppenderFactory AppenderFactory { get; }

        ILayoutFactory LayoutFactory { get; }

        ILogger CreateLogger();
    }
}
