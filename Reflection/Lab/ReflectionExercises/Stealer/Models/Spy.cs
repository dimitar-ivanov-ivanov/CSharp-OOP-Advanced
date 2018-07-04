using System.Reflection;
using System.Linq;
using System;
using System.Text;

namespace Stealer.Models
{
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
    }
}
