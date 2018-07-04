namespace Linked_List_Traversal.Core
{
    using Linked_List_Traversal.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine<T>
    {
        private IMyLinkedList<T> myLinkedList;
        private MethodInfo[] methods;

        private const BindingFlags Flags = BindingFlags.Static | BindingFlags.Instance |
            BindingFlags.Public | BindingFlags.NonPublic;

        public Engine(IMyLinkedList<T> myLinkedList)
        {
            this.myLinkedList = myLinkedList;
            this.methods = myLinkedList
                .GetType()
                .GetMethods(Flags);
        }

        public void Run()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var method = this.methods
                    .FirstOrDefault(x => x.Name == args[0]);

                var nonParsedParams = args.Skip(1).ToArray();
                var methodParams = method.GetParameters();
                var parsedParams = new object[methodParams.Length];

                for (int j = 0; j < methodParams.Length; j++)
                {
                    parsedParams[j] = (T)Convert.ChangeType(nonParsedParams[j],
                        typeof(T));
                }

                method.Invoke(this.myLinkedList, parsedParams);
            }

            Console.WriteLine(this.myLinkedList.Count);
            Console.WriteLine(string.Join(" ", myLinkedList));
        }
    }
}
