namespace ListyIterator.Core
{
    using ListyIterator.Contracts;
    using System;

    public class Engine<T>
    {
        private IListyIterator<T> listy;

        private const string TerminatingCommand = "END";

        public Engine(IListyIterator<T> listy)
        {
            this.listy = listy;
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
                        case "Move":
                            Console.WriteLine(listy.MoveNext());
                            break;
                        case "Print":
                            listy.Print();
                            break;
                        case "HasNext":
                            Console.WriteLine(listy.HasNext());
                            break;
                        default:
                            break;
                    }
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
