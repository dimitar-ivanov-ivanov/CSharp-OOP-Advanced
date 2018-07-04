namespace Linked_List_Traversal
{
    using Linked_List_Traversal.Core;
    using Linked_List_Traversal.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var myLinkedList = new MyLinkedList<int>();
            var engine = new Engine<int>(myLinkedList);
            engine.Run();
        }
    }
}
