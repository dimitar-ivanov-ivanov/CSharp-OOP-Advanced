namespace Work_Force.Models.Employees
{
    public abstract class Employee
    {
        private string name;
        private int workHoursPerWeek;

        protected Employee(string name, int workHoursPerWeek)
        {
            this.name = name;
            this.workHoursPerWeek = workHoursPerWeek;
        }

        public string Name { get => name; set => name = value; }

        public int WorkHoursPerWeek { get => workHoursPerWeek; set => workHoursPerWeek = value; }
    }
}
