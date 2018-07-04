namespace Inferno_Infinity.Factories
{
    using Inferno_Infinity.Contracts;
    using Inferno_Infinity.Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string gemType, string gemClarityName)
        {
            var type = Assembly
                        .GetExecutingAssembly()
                        .GetTypes()
                        .FirstOrDefault(x => x.Name == gemType);

            var gemClarity = (GemClarity)Enum.Parse(typeof(GemClarity), gemClarityName);

            return (IGem)Activator.CreateInstance(type, new object[] { gemClarity });
        }
    }
}
