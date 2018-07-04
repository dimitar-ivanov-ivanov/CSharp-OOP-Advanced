namespace Work_Force.Models.Employees
{
    public class PartTimeEmployee : Employee
    {
        private const int WorkHours = 20;

        public PartTimeEmployee(string name) 
            : base(name, 20)
        {
        }
    }
}
