namespace Emergency_Skeleton.Factories
{
    using Emergency_Skeleton.Contracts;
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;
    using System;
    using System.Linq;
    using System.Reflection;

    public class EmergencyFactory : IEmergencyFactory
    {
        public IEmergency CreateEmergency(string type,string description, string level, string registrationTimeStr, string secondary)
        {
            var emergencyLevel = Enum.Parse(typeof(EmergencyLevel), level);
            var registrationTime = new RegistrationTime(registrationTimeStr);

            var typeToActivate = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            var typeParams = new object[] { description, emergencyLevel, registrationTime, secondary };

            var activatedClass = (IEmergency)Activator.CreateInstance(typeToActivate, typeParams);

            return activatedClass;
        }
    }
}
