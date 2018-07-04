namespace LambdaCore_Skeleton.Factories
{
    using LambdaCore_Skeleton.Contracts;
    using LambdaCore_Skeleton.Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CoreFactory : ICoreFactory
    {
        public ICore Create(string name, string type, int durability)
        {
            var coreType = (CoreType)Enum.Parse(typeof(CoreType), type);

            var typeToActivate = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type + "Core");

            var activatedClass = (ICore)Activator.CreateInstance(typeToActivate, coreType, durability, name);

            return activatedClass;
        }
    }
}
