namespace Black_Box_Integer.Core
{
    using P02_BlackBoxInteger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Engine
    {
        private BlackBoxInteger box;
        private Dictionary<string, MethodInfo> methods;
        private Dictionary<string, ParameterInfo[]> parameters;

        private const string TerminatingCommand = "END";

        private const BindingFlags Flags =
            BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.Static;

        public Engine()
        {
            var type = typeof(BlackBoxInteger);

            this.methods = type.GetMethods(Flags)
                .ToDictionary(x => x.Name, y => y);

            this.parameters = this.methods
                .ToDictionary(x => x.Key, y => y.Value.GetParameters());

            var constructors = type.GetConstructors(Flags)[1];

            this.box = (BlackBoxInteger)constructors
                .Invoke(new object[] { });
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != TerminatingCommand)
            {
                var args = input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                var methodName = args[0];
                var methodToInvoke = methods[methodName];

                var nonParsedParms = args.Skip(1).ToArray();
                var parsedParams = new object[nonParsedParms.Length];
                var methodParams = parameters[methodName];

                for (int i = 0; i < methodParams.Length; i++)
                {
                    var type = methodParams[i].ParameterType;
                    parsedParams[i] = Convert.ChangeType(nonParsedParms[i], type);
                }

                methodToInvoke.Invoke(box, parsedParams);
                Console.WriteLine(box.InnerValue);

                input = Console.ReadLine();
            }
        }
    }
}
