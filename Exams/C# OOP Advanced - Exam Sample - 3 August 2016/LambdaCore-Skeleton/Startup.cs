namespace LambdaCore_Skeleton
{
    using LambdaCore_Skeleton.Core;
    using LambdaCore_Skeleton.Factories;
    using LambdaCore_Skeleton.IO;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var fragmentFactory = new FragmentFactory();
            var coreFactory = new CoreFactory();
            var powerPlant = new PowerPlant(fragmentFactory,coreFactory);

            var commandInterpreter = new CommandInterpreter(powerPlant);
            var reader = new Reader();
            var writer = new Writer();
            var engine = new Engine(reader,writer,commandInterpreter);

            engine.Run();
        }
    }
}
