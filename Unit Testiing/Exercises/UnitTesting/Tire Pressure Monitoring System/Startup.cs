namespace Tire_Pressure_Monitoring_System
{
    using Tire_Pressure_Monitoring_System.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var alarm = new Alarm();

            alarm.Check();
        }
    }
}