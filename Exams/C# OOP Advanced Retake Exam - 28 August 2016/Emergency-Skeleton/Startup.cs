namespace Emergency_Skeleton
{
    using Emergency_Skeleton.Core;
    using Emergency_Skeleton.Factories;
    using Emergency_Skeleton.IO;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var emergencyFactory = new EmergencyFactory();
            var emergencyCenterFactory = new EmergencyCenterFactory();

            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var emergencyManagementSystem = new EmergencyManagementSystem(emergencyFactory, emergencyCenterFactory);
            var engine = new Engine(emergencyManagementSystem, reader, writer);
            engine.Run();
        }
    }
}
