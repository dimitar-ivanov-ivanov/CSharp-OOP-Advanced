namespace Create_DateTime.Models
{
    using System;
    using Create_DateTime.Contracts;

    public class MyDatetime : IDateTime
    {
        public void AddDays(DateTime date, double daysToAdd)
        {
            throw new NotImplementedException();
        }

        public DateTime Now()
        {
            return DateTime.Now;
        }

        public TimeSpan SubstractDays(DateTime date, int daysToSubstract)
        {
            var date1 = DateTime.Parse($"{daysToSubstract}");

            return date.Subtract(date1); 
        }
    }
}
