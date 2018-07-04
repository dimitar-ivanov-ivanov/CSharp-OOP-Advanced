using System;
using System.Linq;
using System.Text;

public class Startup
{
    public static void Main(string[] args)
    {
        Execute();
    }

    private static void Execute()
    {
        WeeklyCalendar calendar = new WeeklyCalendar();
        calendar.AddEntry("Monday", "Internal meeting");
        calendar.AddEntry("Tuesday", "Create presentation");
        calendar.AddEntry("Tuesday", "Create lab and exercise");
        calendar.AddEntry("Thursday", "Enum Lecture");
        calendar.AddEntry("Monday", "Second internal meeting");

        var ordered = calendar.WeeklySchedule.OrderBy(n => n).ToList();
        var output = new StringBuilder();

        foreach (var weeklyEntry in ordered)
        {
            output.AppendLine(weeklyEntry.ToString());
        }

        Console.Write(output);
    }
}
