namespace CustomEnumAttribute
{
    using CustomEnumAttribute.Attributes;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var input = Console.ReadLine();
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == input);

            var attribute = type.GetCustomAttribute<TypeAttribute>();

            Console.WriteLine(attribute);
        }
    }
}
