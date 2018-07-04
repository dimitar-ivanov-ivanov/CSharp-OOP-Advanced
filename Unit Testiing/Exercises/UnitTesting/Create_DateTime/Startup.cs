namespace Create_DateTime
{
    using System.Globalization;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }
    }
}
