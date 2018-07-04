namespace Create_Logger.Models.Layouts
{
    using Create_Logger.Contracts;

    public class XmlLayout : ILayout
    {
        public string FormatMessage(string dateTime, string reportLevel, string message)
        {
            return "<log>\n" +
                   $"   <date>{dateTime}</date>\n" +
                   $"   <level>{reportLevel.ToUpper()}</level>\n" +
                   $"   <message>{message}</message>\n" +
                   "</log>";
        }
    }
}
