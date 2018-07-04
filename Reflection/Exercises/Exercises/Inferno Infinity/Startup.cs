namespace Inferno_Infinity
{
    using Inferno_Infinity.Core;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            //var weaponFactory = new WeaponFactory();
            //var gemFactory = new GemFactory();
            //var commandInterpreter = new CommandInterpreter(weaponFactory, gemFactory);

            //var engine = new Engine(commandInterpreter, weaponFactory, gemFactory);
            //engine.Run();

            var engine = new AttributeEngine();
            engine.Run();
        } 
    }
}
