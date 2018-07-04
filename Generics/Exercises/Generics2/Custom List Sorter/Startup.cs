namespace Custom_List_Sorter
{
    using Custom_List_Sorter.Core;
    using Custom_List_Sorter.Models;

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
