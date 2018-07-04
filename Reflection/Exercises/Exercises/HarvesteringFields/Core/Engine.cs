namespace HarvesteringFields.Core
{
    using P01_HarvestingFields.Models;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine
    {
        private FieldInfo[] fields;

        private const string TerminatingCommand = "HARVEST";

        private const BindingFlags flags
            = BindingFlags.Instance | BindingFlags.Static |
              BindingFlags.Public | BindingFlags.NonPublic;

        public Engine()
        {
            this.fields = typeof
                (HarvestingFields)
                .GetFields(flags);
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while(input != TerminatingCommand)
            {
                if(input == "protected")
                {
                    input = "family";
                }

                var fieldsToPrint = new FieldInfo[] { };

                if(input == "all")
                {
                    fieldsToPrint = this.fields.ToArray();
                }
                else
                {
                    fieldsToPrint =
                        this.fields
                        .Where(x => x.Attributes.ToString().ToLower() == input)
                        .ToArray();
                }

                foreach (var field in fieldsToPrint)
                {
                    var attribute = field.Attributes.ToString().ToLower();

                    if(attribute == "family")
                    {
                        attribute = "protected";
                    }

                    Console.WriteLine($"{attribute} {field.FieldType.Name} {field.Name}");
                }

                input = Console.ReadLine();
            }
        }
    }
}
