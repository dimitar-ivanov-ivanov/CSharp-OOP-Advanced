using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        var typeToActivate = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == soldierTypeName);

        return (ISoldier)Activator.CreateInstance(typeToActivate, name, age, experience, endurance);
    }
}