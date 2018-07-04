using System.Collections.Generic;

public class WeeklyCalendar
{
    private List<WeeklyEntry> weeklySchedule;
    public List<WeeklyEntry> WeeklySchedule => weeklySchedule;

    public WeeklyCalendar()
    {
        this.weeklySchedule = new List<WeeklyEntry>();
    }

    public void AddEntry(string weekDay,string notes)
    {
        weeklySchedule.Add(new WeeklyEntry(weekDay, notes));
    }
}
