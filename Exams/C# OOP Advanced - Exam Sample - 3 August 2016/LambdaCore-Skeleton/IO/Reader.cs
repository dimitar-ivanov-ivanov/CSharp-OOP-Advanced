namespace LambdaCore_Skeleton.IO
{
    using LambdaCore_Skeleton.Contracts;
    using System;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
