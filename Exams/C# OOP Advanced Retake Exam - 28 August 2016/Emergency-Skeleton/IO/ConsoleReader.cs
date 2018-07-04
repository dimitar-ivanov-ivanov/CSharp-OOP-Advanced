namespace Emergency_Skeleton.IO
{
    using Emergency_Skeleton.Contracts;
    using System;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadKey().ToString();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
