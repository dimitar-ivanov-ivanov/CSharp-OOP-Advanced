namespace Emergency_Skeleton.Core
{
    using Emergency_Skeleton.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Engine : IEngine
    {
        private IEmergencyManagementSystem emergencyManagementSystem;
        private IReader reader;
        private IWriter writer;

        private Dictionary<string, MethodInfo> methods;
        private Dictionary<string, ParameterInfo[]> paramaters;

        private const string TerminatingCommand = "EmergencyBreak";

        public Engine(IEmergencyManagementSystem emergencyManagementSystem, IReader reader, IWriter writer)
        {
            this.emergencyManagementSystem = emergencyManagementSystem;

            this.methods = this.emergencyManagementSystem
                .GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.Static)
                .ToDictionary(x => x.Name, y => y);

            this.paramaters = this.methods
                .ToDictionary(x => x.Key, y => y.Value.GetParameters());

            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            var input = reader.ReadLine();

            while (input != TerminatingCommand)
            {
                var args = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                var name = args[0];
                var nonParsedParams = args.Skip(1).ToArray();

                var method = this.methods[name];
                var methodParams = this.paramaters[name];
                var parsedParams = new object[methodParams.Length];

                for (int i = 0; i < methodParams.Length; i++)
                {
                    var typeToConvert = methodParams[i].ParameterType;

                    parsedParams[i] = Convert.ChangeType(nonParsedParams[i], typeToConvert);
                }

                var invocation = (string)method.Invoke(emergencyManagementSystem, parsedParams);

                writer.WriteLine(invocation);

                input = reader.ReadLine();
            }
        }
    }
}
