namespace High_Quality_Mistakes.Models
{
    using System.Reflection;
    using System.Linq;
    using System;
    using System.Text;

    public class Spy
    {
        public string StealMethodInfo(string classToInvestigate, params string[] fields)
        {
            var classType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == classToInvestigate);

            var activatedClass = (Hacker)Activator.CreateInstance(classType);

            var output = new StringBuilder();
            output.AppendLine($"Class under investigation: {classToInvestigate}");

            for (int i = 0; i < fields.Length; i++)
            {
                var field = classType.GetField(fields[i],
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                var fieldValue = field.GetValue(activatedClass);
                output.AppendLine($"{field.Name} = {fieldValue}");

            }

            output = output.Remove(output.Length - 2, 2);

            return output.ToString();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            var classType = Assembly
             .GetExecutingAssembly()
             .GetTypes()
             .FirstOrDefault(x => x.Name == className);

            var publicFields = classType.GetFields(BindingFlags.Public |
                BindingFlags.Instance | BindingFlags.Static);

            var publicMethods = classType.GetMethods(BindingFlags.Public
                | BindingFlags.Instance | BindingFlags.Static);

            var nonPublicMethods = classType.GetMethods(BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static);

            var getters = nonPublicMethods.Where(x => x.Name.StartsWith("get"));
            var setters = publicMethods.Where(x => x.Name.StartsWith("set"));

            var output = new StringBuilder();

            foreach (var field in publicFields)
            {
                output.AppendLine($"{field.Name} must be private!");
            }

            foreach (var getter in getters)
            {
                output.AppendLine($"{getter.Name} have to be public!");
            }

            foreach (var setter in setters)
            {
                output.AppendLine($"{setter.Name} have to be private!");
            }

            if(output.Length != 0)
            {
                output = output.Remove(output.Length - 2, 2);
            }

            return output.ToString();
        }
    }
}
