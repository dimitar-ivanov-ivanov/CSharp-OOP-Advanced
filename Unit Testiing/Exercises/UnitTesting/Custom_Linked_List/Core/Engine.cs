namespace Custom_Linked_List.Core
{
    using Custom_Linked_List.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Engine<T>
    {
        private ICustomLinkedList<T> customLinkedList;
        private IDictionary<string, MethodInfo> methods;
        private IDictionary<string, ParameterInfo[]> parameters;

        private BindingFlags Flags = BindingFlags.Static | BindingFlags.Instance |
            BindingFlags.Public | BindingFlags.NonPublic;

        public Engine(ICustomLinkedList<T> customLinkedList)
        {
            this.customLinkedList = customLinkedList;
            this.methods = customLinkedList.GetType()
                .GetMethods(Flags)
                .ToDictionary(x => x.Name, y => y);

            this.parameters = this.methods
                .ToDictionary(x => x.Key, x => x.Value.GetParameters());
        }

        public void Run()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var methodName = args[0];

                var methodToInvoke = this.methods[methodName];
                var methodParams = this.parameters[methodName];
 
                var nonParsedParams = args.Skip(1).ToArray();
                var parsedParams = new object[methodParams.Length];

                for (int j = 0; j < methodParams.Length; j++)
                {
                    var toConvert = methodParams[j].ParameterType;

                    parsedParams[j] = Convert.ChangeType(nonParsedParams[j], toConvert);
                }

                var res = methodToInvoke.Invoke(customLinkedList, parsedParams);
                if(res != null)
                {
                    Console.WriteLine(res);
                }
            }
        }
    }
}
