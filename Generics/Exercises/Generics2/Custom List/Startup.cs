namespace Custom_List
{
    using Custom_List.Core;
    using Custom_List.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var engine = new Engine();
            var commandInterpreter = new CommandInterpreter<string>();
            engine.Run(commandInterpreter);
        }
    }
}
