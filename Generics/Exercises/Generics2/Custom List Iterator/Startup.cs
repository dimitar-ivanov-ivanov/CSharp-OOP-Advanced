namespace Custom_List_Iterator
{
    using Custom_List_Iterator.Core;
    using Custom_List_Iterator.Models;

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
