namespace Emergency_Skeleton.Models.Emergencies
{
    using System.Collections.Generic;
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;

    public class PropertyEmergency : BaseEmergency
    {
        public PropertyEmergency(string description, EmergencyLevel emergencyLevel, 
            RegistrationTime registrationTime,string propertyDamage) 
            : base(description, emergencyLevel, registrationTime)
        {
            this.PropertyDamage = int.Parse(propertyDamage);
        }

        public int PropertyDamage { get; private set; }

        public override KeyValuePair<string, int> GetSecondaryParameter()
        {
            return new KeyValuePair<string, int>("damageFixed", this.PropertyDamage);
        }
    }
}
