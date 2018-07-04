namespace P04.Recharge
{
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            Execute();
        }

        private static void Execute()
        {
            var robot = new Robot("1", 2);
            var employee = new Employee("2");
            var robots = new List<IRechargeable>() { robot };
            var cs = new ChargingStation(robots);
        }
    }
}