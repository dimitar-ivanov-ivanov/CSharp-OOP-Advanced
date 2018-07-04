namespace Create_Logger.Models.Appenders
{
    using Create_Logger.Contracts;
    using Create_Logger.Enums;

    public class FileAppender : Appender
    {
        private ILog file;

        public FileAppender(ILayout layout, ILog file, ReportLevel reportLevel = ReportLevel.INFO)
            : base(layout, reportLevel)
        {
            this.file = file;
        }

        public ILog File
        {
            get { return this.file; }
            private set { this.file = value; }
        }

        public override void Append(string dateTime, string reportLevel, string message)
        {
            if (base.ReadyToAppend(reportLevel))
            {
                file.Write(Layout.FormatMessage(dateTime, reportLevel, message));
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.File.Size}";
        }
    }
}
