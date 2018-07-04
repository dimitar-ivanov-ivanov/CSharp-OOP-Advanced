namespace Generic_Array_Creator
{
    using Generic_Array_Creator.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var strings = ArrayCreator.Create(5, "Pesho");
            var integers = ArrayCreator.Create(10, 33);
        }
    }
}