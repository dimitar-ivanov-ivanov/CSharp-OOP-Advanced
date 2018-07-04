namespace Custom_List_Iterator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Custom_List_Iterator.Contracts;

    public class Engine : IEngine
    {
        private const string TerminatingCommand = "END";
        private IList<string> methodsToPrint;

        public Engine()
        {
            methodsToPrint = new List<string>()
            {
                "Contains",
                "Greater",
                "Max",
                "Min",
                "Print"
            };
        }

        public void Run<T>(ICommandInterpreter<T> commandInterpreter)
            where T : IComparable<T>
        {
            var commandInterpreterMethods = commandInterpreter
                   .GetType()
                   .GetMethods();

            var input = Console.ReadLine();

            while (input != TerminatingCommand)
            {
                var commandArgs = SplitStringByChar(input, ' ');
                var methodName = commandArgs[0];
                var methodNonParsedParams = commandArgs.Skip(1).ToArray();

                var methodToInvoke = commandInterpreterMethods
                    .FirstOrDefault(x => x.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                var methodParams = methodToInvoke.GetParameters();
                var parsedParams = new object[methodNonParsedParams.Length];

                for (int i = 0; i < methodNonParsedParams.Length; i++)
                {
                    var paramType = methodParams[i].ParameterType;
                    var toConvert = methodNonParsedParams[i];

                    parsedParams[i] = Convert.ChangeType
                        (toConvert, paramType);
                }

                var result = methodToInvoke.Invoke(commandInterpreter, parsedParams);
                if (result != null && methodsToPrint.Contains(methodName))
                {
                    Console.WriteLine(result);
                }

                input = Console.ReadLine();
            }
        }

        private string[] SplitStringByChar(string toSpit, params char[] toSplitBy)
        {
            return toSpit.Split(toSplitBy,
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
