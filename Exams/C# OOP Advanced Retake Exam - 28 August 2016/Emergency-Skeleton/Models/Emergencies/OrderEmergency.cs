namespace Emergency_Skeleton.Models.Emergencies
{
    using System.Collections.Generic;
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;

    public class OrderEmergency : BaseEmergency
    {
        public OrderEmergency(string description, EmergencyLevel emergencyLevel,
            RegistrationTime registrationTime, string specialStr)
            : base(description, emergencyLevel, registrationTime)
        {
            this.Status = specialStr == "Special";
        }

        public bool Status { get; private set; }

        public override KeyValuePair<string, int> GetSecondaryParameter()
        {
            var secondParam = Status ? 1 : 0;
            return new KeyValuePair<string, int>("specialCases", secondParam);
        }
    }
}
