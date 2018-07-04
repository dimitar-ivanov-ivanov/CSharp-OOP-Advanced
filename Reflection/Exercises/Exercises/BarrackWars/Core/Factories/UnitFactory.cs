namespace BarrackWars.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using BarrackWars.Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == unitType);

            var unit = (IUnit)Activator.CreateInstance(type);

            return unit;
        }
    }
}
