namespace Create_Logger.Contracts
{
    public interface ILayout
    {
        string FormatMessage(string dateTime, string reportLevel, string message);
    }
}
