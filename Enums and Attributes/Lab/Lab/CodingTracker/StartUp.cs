namespace CodingTracker
{
    using CodingTracker.Models;
    using CreateAttribute.Attributes;

    [Softuni("Ventsi")]
    public class StartUp
    {
        [Softuni("Gosho")]
        public static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}