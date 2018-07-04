namespace Create_Logger.Models.Layouts
{
    using Create_Logger.Contracts;

    public class SimpleLayout : ILayout
    {
        public string FormatMessage(string dateTime, string reportLevel, string message)
        {
            return $"{dateTime} - {reportLevel.ToUpper()} - {message}";
        }
    }
}
