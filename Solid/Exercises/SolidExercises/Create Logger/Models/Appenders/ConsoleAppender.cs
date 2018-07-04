namespace Create_Logger.Models.Appenders
{
    using Create_Logger.Contracts;
    using Create_Logger.Enums;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.INFO)
            : base(layout, reportLevel)
        {
        }

        public override void Append(string dateTime, string reportLevel, string message)
        {
            if (this.ReadyToAppend(reportLevel))
            {
                Console.WriteLine(Layout.FormatMessage(dateTime, reportLevel, message));
            }
        }
    }
}
