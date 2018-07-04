namespace Inferno_Infinity.Core
{
    using Inferno_Infinity.Attributes;
    using Inferno_Infinity.Contracts;
    using Inferno_Infinity.Enums;
    using Inferno_Infinity.Models.Weapons;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AttributeEngine : IEngine
    {
        private const string TerminatingCommand = "END";
        private const BindingFlags Flags = BindingFlags.Static | BindingFlags.Instance
            | BindingFlags.Public | BindingFlags.NonPublic;

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != TerminatingCommand)
            {
                var tempWeapon = new Axe("temp", ItemRarity.Common);

                var attribute = tempWeapon
                    .GetType()
                    .GetCustomAttribute<WeaponAttribute>();

                var fieldToOutput = attribute.GetType()
                    .GetProperties(Flags)
                    .FirstOrDefault(x => x.Name.Equals(input, StringComparison.OrdinalIgnoreCase))
                    .GetValue(attribute);

                if (input == "Description")
                {
                    input = "Class description";
                }

                if (input == "Reviewers")
                {
                    Console.WriteLine($"{input}: {string.Join(", ", (string[])fieldToOutput)}");
                }
                else
                {
                    Console.WriteLine($"{input}: {fieldToOutput}");
                }

                input = Console.ReadLine();
            }
        }
    }
}
