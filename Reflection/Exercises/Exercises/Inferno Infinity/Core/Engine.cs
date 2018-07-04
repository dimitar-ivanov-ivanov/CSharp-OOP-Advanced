namespace Inferno_Infinity.Core
{
    using Inferno_Infinity.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine
    {
        private ICommandInterpreter commandInterpreter;
        private IWeaponFactory weaponFactory;
        private IGemFactory gemFactory;

        private MethodInfo[] methods;

        private const string TerminatingCommand = "END";
        private const BindingFlags Flags = BindingFlags.Static | BindingFlags.Instance |
                     BindingFlags.Public | BindingFlags.NonPublic;

        public Engine(ICommandInterpreter commandInterpreter,
            IWeaponFactory weaponFactory, IGemFactory gemFactory)
        {
            this.commandInterpreter = commandInterpreter;
            this.gemFactory = gemFactory;
            this.weaponFactory = weaponFactory;

            this.methods = commandInterpreter.GetType()
                .GetMethods(Flags);
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while (input != TerminatingCommand)
            {
                var args = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var methodName = args[0];
                args = args.Skip(1).ToArray();

                var methodToInvoke = this.methods
                    .FirstOrDefault(x => x.Name == methodName);

                methodToInvoke.Invoke(this.commandInterpreter,
                    new object[] { args });

                input = Console.ReadLine();
            }
        }
    }
}
