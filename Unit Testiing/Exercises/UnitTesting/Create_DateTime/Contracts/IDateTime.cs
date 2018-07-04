namespace Create_DateTime.Contracts
{
    using System;

    public interface IDateTime
    {
        DateTime Now();

        void AddDays(DateTime date, double daysToAdd);

        TimeSpan SubstractDays(DateTime date, int daysToSubstract);
    }
}
