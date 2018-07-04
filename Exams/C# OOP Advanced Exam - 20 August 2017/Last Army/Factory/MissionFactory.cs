using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        var typeToActivate = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(x => x.Name == difficultyLevel);

        return (IMission)Activator.CreateInstance(typeToActivate, neededPoints);
    }
}
