﻿namespace Create_Collection
{
    using Create_Collection.Core;
    using Create_Collection.Models;
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var listyIterator = new ListyIterator<string>(args.Skip(1).ToList());
            var engine = new Engine<string>(listyIterator);
            engine.Run();
        }
    }
}