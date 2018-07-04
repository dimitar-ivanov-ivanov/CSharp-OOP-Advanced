namespace Create_Stack.Core
{
    using Create_Stack.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine<T>
    {
        private IMyStack<T> myStack;
        private MethodInfo[] methods;

        private const string TerminatingCommand = "END";
        private const BindingFlags Flags = BindingFlags.Instance |
            BindingFlags.Static | BindingFlags.NonPublic |
            BindingFlags.Public;

        public Engine(IMyStack<T> myStack)
        {
            this.myStack = myStack;

            this.methods = myStack
                .GetType()
                .GetMethods(Flags);
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != TerminatingCommand)
            {
                var args = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var methodName = args[0];

                var methodToInvoke = this.methods
                    .FirstOrDefault(x => x.Name == methodName);

                var nonParsedParams = args.Skip(1).ToArray();
                var methodParams = methodToInvoke.GetParameters();
                var parsedParams = new object[methodParams.Length];

                for (int i = 0; i < methodParams.Length; i++)
                {
                    var arrayToInput = new T[nonParsedParams.Length];
                    for (int j = 0; j < nonParsedParams.Length; j++)
                    {
                        arrayToInput[j] = (T)Convert.ChangeType(nonParsedParams[j], typeof(T));
                    }
                    parsedParams[i] = arrayToInput;
                } 

                methodToInvoke.Invoke(this.myStack, parsedParams);

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", myStack));
            Console.WriteLine(string.Join("\n", myStack));

        }
    }
}
