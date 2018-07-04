namespace Work_Force.Models.Employees
{
    public class StandartEmployee : Employee
    {
        private const int WorkHours = 40;

        public StandartEmployee(string name) 
            : base(name, WorkHours)
        {
        }
    }
}
