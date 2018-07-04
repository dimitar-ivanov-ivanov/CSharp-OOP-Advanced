namespace Emergency_Skeleton.IO
{
    using Emergency_Skeleton.Contracts;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void Write(string output)
        {
            Console.Write(output);
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
