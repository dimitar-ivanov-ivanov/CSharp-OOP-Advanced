namespace Create_Logger.Models.Logs
{
    using Create_Logger.Contracts;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LogFile : ILog
    {
        private StringBuilder builder;

        private const string AppendFileName = "\\log.txt";

        public LogFile()
        {
            this.builder = new StringBuilder();
        }

        public int Size => builder.ToString()
            .Where(x => char.IsLetter(x))
            .Sum(x => x);

        public void Write(string message)
        {
            builder.AppendLine(message);

            File.AppendAllText(Directory.GetCurrentDirectory() + AppendFileName, message);
        }
    }
}
