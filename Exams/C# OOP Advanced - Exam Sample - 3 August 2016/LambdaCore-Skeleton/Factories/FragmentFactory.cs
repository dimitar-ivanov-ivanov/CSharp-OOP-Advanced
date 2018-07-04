namespace LambdaCore_Skeleton.Factories
{
    using LambdaCore_Skeleton.Contracts;
    using LambdaCore_Skeleton.Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class FragmentFactory : IFragmentFactory
    {
        public IFragment Create(string name, string type, int pressureAffection)
        {
            var fragmentType = (FragmentType)Enum.Parse(typeof(FragmentType), type);

            var typeToActivate = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type + "Fragment");

            var activatedClass = (IFragment)Activator.CreateInstance(typeToActivate, name, pressureAffection, fragmentType);

            return activatedClass;
        }
    }
}
