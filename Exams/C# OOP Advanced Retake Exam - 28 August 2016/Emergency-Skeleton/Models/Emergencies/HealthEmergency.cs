namespace Emergency_Skeleton.Models.Emergencies
{
    using System.Collections.Generic;
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;

    public class HealthEmergency : BaseEmergency
    {
        public HealthEmergency(string description, EmergencyLevel emergencyLevel, 
            RegistrationTime registrationTime,string numberOfCasulties) 
            : base(description, emergencyLevel, registrationTime)
        {
            this.NumberOfCasulties = int.Parse(numberOfCasulties);
        }

        public int NumberOfCasulties { get; private set; }

        public override KeyValuePair<string, int> GetSecondaryParameter()
        {
            return new KeyValuePair<string, int>("casualtiesSaved",NumberOfCasulties);
        }
    }
}
