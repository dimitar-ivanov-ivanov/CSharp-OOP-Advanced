namespace LambdaCore_Skeleton.IO
{
    using LambdaCore_Skeleton.Contracts;
    using System;

    public class Writer : IWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
