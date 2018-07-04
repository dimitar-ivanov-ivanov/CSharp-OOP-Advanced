namespace Emergency_Skeleton.Core
{
    using Emergency_Skeleton.Collection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    using Emergency_Skeleton.Contracts;

    public class EmergencyManagementSystem : IEmergencyManagementSystem
    {
        private Dictionary<string, IRegister<IEmergency>> emergencies;
        private Dictionary<string, IRegister<IEmergencyCenter>> emergencyCenters;
        private IEmergencyFactory emergencyFactory;
        private IEmergencyCenterFactory emergencyCenterFactory;

        private int damageFixed;
        private int casualtiesSaved;
        private int specialCases;

        private int totalProcessedEmergencies;

        public EmergencyManagementSystem(IEmergencyFactory emergencyFactory, IEmergencyCenterFactory emergencyCenterFactory)
        {
            this.emergencies = new Dictionary<string, IRegister<IEmergency>>();
            this.emergencyCenters = new Dictionary<string, IRegister<IEmergencyCenter>>();

            emergencies.Add("Property", new Register<IEmergency>());
            emergencies.Add("Health", new Register<IEmergency>());
            emergencies.Add("Order", new Register<IEmergency>());

            emergencyCenters.Add("Property", new Register<IEmergencyCenter>());
            emergencyCenters.Add("Health", new Register<IEmergencyCenter>());
            emergencyCenters.Add("Order", new Register<IEmergencyCenter>());

            this.emergencyFactory = emergencyFactory;
            this.emergencyCenterFactory = emergencyCenterFactory;
        }

        public string RegisterPropertyEmergency(string description, string level, string registrationTime, string secondary)
        {
            var emergency = emergencyFactory.CreateEmergency("PropertyEmergency", description, level, registrationTime, secondary);

            var propType = "Property";
            emergencies[propType].Enqueue(emergency);

            return string.Format(Constants.Constants.RegisterEmergency, propType, emergency.Level, emergency.Time);
        }

        public string RegisterHealthEmergency(string description, string level, string registrationTime, string secondary)
        {
            var emergency = emergencyFactory.CreateEmergency("HealthEmergency", description, level, registrationTime, secondary);

            var propType = "Health";
            emergencies[propType].Enqueue(emergency);

            return string.Format(Constants.Constants.RegisterEmergency, propType, emergency.Level, emergency.Time);
        }

        public string RegisterOrderEmergency(string description, string level, string registrationTime, string secondary)
        {
            var emergency = emergencyFactory.CreateEmergency("OrderEmergency", description, level, registrationTime, secondary);

            var propType = "Order";
            emergencies[propType].Enqueue(emergency);

            return string.Format(Constants.Constants.RegisterEmergency, propType, emergency.Level, emergency.Time);
        }

        public string RegisterFireServiceCenter(string name, int amountOfMaximumEmergencies)
        {
            var center = emergencyCenterFactory.CreateFactory("FiremanServiceCenter", name, amountOfMaximumEmergencies);

            var propType = "Property";
            emergencyCenters[propType].Enqueue(center);

            return string.Format(Constants.Constants.RegisterEmergyCenters, "Fire", name);
        }

        public string RegisterMedicalServiceCenter(string name, int amountOfMaximumEmergencies)
        {
            var center = emergencyCenterFactory.CreateFactory("MedicalServiceCenter", name, amountOfMaximumEmergencies);

            var propType = "Health";
            emergencyCenters[propType].Enqueue(center);

            return string.Format(Constants.Constants.RegisterEmergyCenters, "Medical", name);
        }

        public string RegisterPoliceServiceCenter(string name, int amountOfMaximumEmergencies)
        {
            var center = emergencyCenterFactory.CreateFactory("PoliceServiceCenter", name, amountOfMaximumEmergencies);

            var propType = "Order";
            emergencyCenters[propType].Enqueue(center);

            return string.Format(Constants.Constants.RegisterEmergyCenters, "Police", name);
        }

        public string ProcessEmergencies(string type)
        {
            var allEmergencies = this.emergencies[type];
            var allCenters = this.emergencyCenters[type];

            while (!allCenters.IsEmpty() && !allEmergencies.IsEmpty())
            {
                var topEmergency = allEmergencies.Peek();
                var topCenter = allCenters.Peek();

                topCenter.AmountOfMaximumEmergencies--;
                if (topCenter.isForRetirement())
                {
                    allCenters.Dequeue();
                }
                else
                {
                    allCenters.Dequeue();
                    allCenters.Enqueue(topCenter);
                }

                var secondParam = topEmergency.GetSecondaryParameter();
                var secondParamCorrectField = this.GetType()
                    .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
                    .FirstOrDefault(x => x.Name == secondParam.Key);

                var newFieldValue = (int)secondParamCorrectField.GetValue(this) + secondParam.Value;

                secondParamCorrectField.SetValue(this, (int)newFieldValue);

                allEmergencies.Dequeue();
                totalProcessedEmergencies++;
            }

            if (!allEmergencies.IsEmpty())
            {
                return string.Format(Constants.Constants.FailedProcessing, type, allEmergencies.Count);
            }

            return string.Format(Constants.Constants.SuccessfulProcessing, type);
        }

        public string EmergencyReport()
        {
            var fireServiceCenters = this.emergencyCenters["Property"].Count;
            var medicalServiceCenters = this.emergencyCenters["Health"].Count;
            var policeServiceCenters = this.emergencyCenters["Order"].Count;

            var currentEmergenciesCount = this.emergencies.Sum(x => x.Value.Count);

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
            return output.ToString();
        }
    }
}
