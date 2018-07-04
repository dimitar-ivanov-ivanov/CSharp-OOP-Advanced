namespace BashSoft
{
    using BashSoft.IO;
    using BashSoft.Judge;
    using BashSoft.Repository;

    public class BashSoftProgram
    {
        static void Main(string[] args)
        {
            var tester = new Tester();
            var ioManager = new IOManager();
            var repo = new StudentsRepository
                (new RepositoryFilter(), new RepositorySorter());

            var currentInterpreter = new CommandInterpreter
                (tester, repo, ioManager);
            var reader = new InputReader(currentInterpreter);

            //for (int i = 0; i < 2; i++)
            //{
            //    ioManager.ChangeCurrentDirectoryRelative("..");
            //}

            //cdabs D:\Vsichki  Programi\Softuni\C# OOP Advanced\BashSoft\StoryMode\BashSoft
            //readDb Files\data.txt
            //cmp D:\Vsichki  Programi\Softuni\C# OOP Advanced\BashSoft\StoryMode\BashSoft\Files\test2.txt
            // D:\Vsichki  Programi\Softuni\C# OOP Advanced\BashSoft\StoryMode\BashSoft\Files\test3.txt
            reader.StartReadingCommands();
        }
    }
}
