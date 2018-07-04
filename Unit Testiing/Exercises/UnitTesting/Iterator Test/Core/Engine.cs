namespace Iterator_Test.Core
{
    using Iterator_Test.Models;
    using System;

    public class Engine
    {
        private ListIterator listIterator;

        private const string TerminatingCommand = "END";

        public Engine(ListIterator listIterator)
        {
            this.listIterator = listIterator;
        }

        public void Run()
        {
            var input = Console.ReadLine();

            while(input != TerminatingCommand)
            {
                try
                {
                    switch (input)
                    {
                        case "HasNext":
                            Console.WriteLine(this.listIterator.HasNext());
                            break;
                        case "Move":
                            Console.WriteLine(this.listIterator.MoveNext());
                            break;
                        case "Print":
                            this.listIterator.Print();
                            break;
                        case "Reset":
                            this.listIterator.Reset();
                            break;
                        default:
                            break;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
