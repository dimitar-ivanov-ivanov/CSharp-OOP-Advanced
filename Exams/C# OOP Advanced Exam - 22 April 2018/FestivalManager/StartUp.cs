namespace FestivalManager
{
    using Core;
    using Entities;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stage stage = new Stage();

            var engine = new Engine(stage);

            engine.Run();
        }
    }
}