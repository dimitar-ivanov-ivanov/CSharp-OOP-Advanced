using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        var typeToActivate = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == ammunitionName);

        return (IAmmunition)Activator.CreateInstance(typeToActivate);
    }
}