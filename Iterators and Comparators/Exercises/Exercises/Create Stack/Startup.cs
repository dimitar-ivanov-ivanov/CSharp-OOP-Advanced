namespace Create_Stack
{
    using Create_Stack.Core;
    using Create_Stack.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var myStack = new MyStack<int>();
            var engine = new Engine<int>(myStack);
            engine.Run();
        }
    }
}