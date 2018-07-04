namespace Emergency_Skeleton.Factories
{
    using Emergency_Skeleton.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class EmergencyCenterFactory  : IEmergencyCenterFactory
    {
        public IEmergencyCenter CreateFactory(string type, string name, int amountOfMaximumEmergencies)
        {
            var typeToActivate = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);

            var activatedType = (IEmergencyCenter)Activator.CreateInstance(typeToActivate, new object[] { name, amountOfMaximumEmergencies });

            return activatedType;
        }
    }
}
