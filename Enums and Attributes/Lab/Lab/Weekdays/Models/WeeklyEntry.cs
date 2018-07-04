using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private WeekDay weekDay;
    private string notes;

    public WeekDay WeekDay => this.weekDay;
    public string Notes => notes;

    public WeeklyEntry(string weekDay,string notes)
    {
        Enum.TryParse(weekDay,out this.weekDay);
        this.notes = notes;
    }

    public override string ToString()
    {
        return $"{this.weekDay} - {this.notes}";
    }

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var weekDayComparison = this.WeekDay.CompareTo(other.WeekDay);
        
        if(weekDayComparison != 0)
        {
            return weekDayComparison;
        }
        return this.Notes.CompareTo(other.Notes);
    }
}