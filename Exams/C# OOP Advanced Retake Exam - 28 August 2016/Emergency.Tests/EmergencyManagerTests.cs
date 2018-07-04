namespace Emergency.Tests
{
    using Emergency_Skeleton.Contracts;
    using Emergency_Skeleton.Core;
    using Emergency_Skeleton.Factories;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    [TestFixture]
    public class EmergencyManagerTests
    {
        private EmergencyManagementSystem emergencyManagementSystem;

        private BindingFlags Flags = BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        private const string RegisterEmergency = "Register{0}Emergency";
        private const string RegisterServiceCenter = "Register{0}ServiceCenter";

        [SetUp]
        public void TestInit()
        {
            this.emergencyManagementSystem = new EmergencyManagementSystem(new EmergencyFactory(), new EmergencyCenterFactory());
        }

        [TestCase("Test", "Minor", "12:24 25/02/2016", "2500", "Property")]
        [TestCase("Test", "Major", "12:24 25/03/2017", "2500", "Property")]
        [TestCase("Test", "Disaster", "24:01 05/02/2016", "2500", "Property")]
        [TestCase("Test", "Minor", "12:24 25/02/2016", "2500", "Health")]
        [TestCase("Test", "Major", "12:24 25/03/2017", "2500", "Health")]
        [TestCase("Test", "Disaster", "24:01 05/02/2016", "2500", "Health")]
        [TestCase("Test", "Minor", "12:24 25/02/2016", "2500", "Order")]
        [TestCase("Test", "Major", "12:24 25/03/2017", "2500", "Order")]
        [TestCase("Test", "Disaster", "24:01 05/02/2016", "2500", "Order")]
        public void RegisterEmergencies(string description, string level, string registrationTime, string secondary, string type)
        {
            var method = GetMethodEmergency(type);
            var paramsToInvoke = new object[] { description, level, registrationTime, secondary };
            var output = (string)method.Invoke(this.emergencyManagementSystem, paramsToInvoke);

            var emergencies = GetEmergencies();

            Assert.AreEqual(emergencies[type].Count, 1);
            Assert.AreEqual(output, $"Registered Public {type} Emergency of level {level} at {registrationTime}.");
        }

        [TestCase("FireService", 2, "Fire")]
        [TestCase("Pirogov", 1, "Medical")]
        [TestCase("3TORPU", 1, "Police")]
        public void RegisterServiceCenters(string name, int amountOfMaximumEmergencies, string type)
        {
            var method = GetMethodEmergencyCenter(type);
            var paramsToInvoke = new object[] { name, amountOfMaximumEmergencies };
            var output = (string)method.Invoke(this.emergencyManagementSystem, paramsToInvoke);

            var emergencyCenters = this.GetEmergencyCenters();

            var typeEmergency = GetTypeEmergency(type);
            Assert.AreEqual(emergencyCenters[typeEmergency].Count, 1);
            Assert.AreEqual(output, $"Registered {type} Service Emergency Center - {name}.");
        }

        [TestCase("Fire")]
        [TestCase("Medical")]
        [TestCase("Police")]
        public void Process(string type)
        {
            var typeEmergency = GetTypeEmergency(type);
            var methodEmergency = GetMethodEmergency(typeEmergency);
            var methodCenter = GetMethodEmergencyCenter(type);

            var paramsEmergency = new object[] { "Test", "Minor", "12:24 25/02/2016", "2500" };
            var paramsCenter = new object[] { "Pirogov", 1 };

            methodEmergency.Invoke(this.emergencyManagementSystem, paramsEmergency);
            methodCenter.Invoke(this.emergencyManagementSystem, paramsCenter);
     
           var output = this.emergencyManagementSystem.ProcessEmergencies(typeEmergency);

            var emergencies = GetEmergencies()[typeEmergency];
            var emergencyCenters = GetEmergencyCenters()[typeEmergency];

            var totalProcessedEmergencies = GetTotalProcessed();

            Assert.AreEqual(emergencies.Count, 0);
            Assert.AreEqual(emergencyCenters.Count, 0);
            Assert.AreEqual(totalProcessedEmergencies, 1);
            Assert.AreEqual(output, $"Successfully responded to all {typeEmergency} emergencies.");
        }

        [Test]
        public void EmergencyReport()
        {
            this.emergencyManagementSystem.RegisterFireServiceCenter("Pirogov", 1);
            this.emergencyManagementSystem.RegisterPropertyEmergency("Test", "Minor", "12:24 25/02/2016", "2500");
            this.emergencyManagementSystem.RegisterPoliceServiceCenter("3TORPU", 2);
            this.emergencyManagementSystem.RegisterPropertyEmergency("Test", "Minor", "12:24 25/02/2016", "2500");

            this.emergencyManagementSystem.ProcessEmergencies("Order");
            this.emergencyManagementSystem.ProcessEmergencies("Property");

            var emergencies = GetEmergencies();
            var emergencyCenters = GetEmergencyCenters();

            var fireServiceCenters = emergencyCenters["Property"].Count;
            var medicalServiceCenters = emergencyCenters["Health"].Count;
            var policeServiceCenters = emergencyCenters["Order"].Count;

            var currentEmergenciesCount = emergencies.Sum(x => x.Value.Count);
            var totalProcessedEmergencies = GetTotalProcessed();

            var damageFixedField = this.emergencyManagementSystem
                     .GetType()
                     .GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                     .FirstOrDefault(x => x.Name == "damageFixed");

            var damageFixed = (int)damageFixedField.GetValue(this.emergencyManagementSystem);

            var casualtiesSavedField = this.emergencyManagementSystem
                     .GetType()
                     .GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                     .FirstOrDefault(x => x.Name == "casualtiesSaved");

            var casualtiesSaved = (int)casualtiesSavedField.GetValue(this.emergencyManagementSystem);

            var specialCasesField = this.emergencyManagementSystem
                  .GetType()
                  .GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                  .FirstOrDefault(x => x.Name == "specialCases");

            var specialCases = (int)specialCasesField.GetValue(this.emergencyManagementSystem);

            var output = new StringBuilder();
            output.AppendLine("PRRM Services Live Statistics");
            output.AppendLine($"Fire Service Centers: {fireServiceCenters}");
            output.AppendLine($"Medical Service Centers: {medicalServiceCenters}");
            output.AppendLine($"Police Service Centers: {policeServiceCenters}");
            output.AppendLine($"Total Processed Emergencies: {totalProcessedEmergencies}");
            output.AppendLine($"Currently Registered Emergencies: {currentEmergenciesCount}");
            output.AppendLine($"Total Property Damage Fixed: {damageFixed}");
            output.AppendLine($"Total Health Casualties Saved: {casualtiesSaved}");
            output.AppendLine($"Total Special Cases Processed: {specialCases}");

            output = output.Remove(output.Length - 2, 2);

            Assert.AreEqual(this.emergencyManagementSystem.EmergencyReport(), output.ToString());
        }

        private int GetTotalProcessed()
        {
            var totalProcessedEmergenciesField = this.emergencyManagementSystem
                        .GetType()
                        .GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                        .FirstOrDefault(x => x.Name == "totalProcessedEmergencies");

            var totalProcessedEmergencies = (int)totalProcessedEmergenciesField.GetValue(this.emergencyManagementSystem);

            return totalProcessedEmergencies;
        }

        private MethodInfo GetMethodEmergency(string type)
        {
            var method = this.emergencyManagementSystem
                .GetType()
                .GetMethods(Flags)
                .FirstOrDefault(x => x.Name == string.Format(RegisterEmergency, type));

            return method;
        }

        private MethodInfo GetMethodEmergencyCenter(string type)
        {
            var method = this.emergencyManagementSystem
                .GetType()
                .GetMethods(Flags)
                .FirstOrDefault(x => x.Name == string.Format(RegisterServiceCenter, type));

            return method;
        }

        private Dictionary<string, IRegister<IEmergency>> GetEmergencies()
        {
            var field = this.emergencyManagementSystem
                .GetType()
                .GetFields(Flags)
                .FirstOrDefault(x => x.Name == "emergencies");

            var res = (Dictionary<string, IRegister<IEmergency>>)field.GetValue(emergencyManagementSystem);

            return res;
        }

        private Dictionary<string, IRegister<IEmergencyCenter>> GetEmergencyCenters()
        {
            var field = this.emergencyManagementSystem
                .GetType()
                .GetFields(Flags)
                .FirstOrDefault(x => x.Name == "emergencyCenters");

            var res = (Dictionary<string, IRegister<IEmergencyCenter>>)field.GetValue(emergencyManagementSystem);

            return res;
        }

        private string GetTypeEmergency(string typeCenter)
        {
            switch (typeCenter)
            {
                case "Fire": return "Property";
                case "Medical": return "Health";
                case "Police": return "Order";
                default: return null;
            }
        }
    }
}
