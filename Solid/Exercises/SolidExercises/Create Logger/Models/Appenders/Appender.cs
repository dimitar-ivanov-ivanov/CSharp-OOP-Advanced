namespace Create_Logger.Models.Appenders
{
    using Create_Logger.Contracts;
    using Create_Logger.Enums;
    using System;

    public abstract class Appender : IAppender
    {
        private ILayout layout;
        private ReportLevel reportLevel;
        private int count;

        public Appender(ILayout layout,
            ReportLevel reportLevel = ReportLevel.INFO)
        {
            this.layout = layout;
            this.ReportLevel = reportLevel;
        }

        public ReportLevel ReportLevel
        {
            get { return this.reportLevel; }
            private set { this.reportLevel = value; }
        }

        public ILayout Layout
        {
            get { return this.layout; }
            private set { this.layout = value; }
        }

        public int Count
        {
            get { return this.count; }
            private set { this.count = value; }
        }

        public abstract void Append(string dateTime, string reportLevel, string message);

        public bool ReadyToAppend(string reportLevel)
        {
            var report = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevel);
            if (report >= this.reportLevel)
            {
                this.Count++;
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.Count}";
        }
    }
}
