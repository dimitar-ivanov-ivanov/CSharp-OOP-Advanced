namespace Custom_Linked_List
{
    using Custom_Linked_List.Core;
    using Custom_Linked_List.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var customList = new CustomLinkedList<int>();
            var engine = new Engine<int>(customList);
            engine.Run();
        }
    }
}
