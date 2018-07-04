namespace Work_Force.Models.Jobs
{
    using Work_Force.Models.Employees;

    public class Job
    {
        private string name;
        private int workRequired;
        private Employee employee;
        private bool isDone;

        public event Engine.JobDoneEventHandler JobDone;

        public Job(string name, int workRequired, Employee employee)
        {
            this.name = name;
            this.workRequired = workRequired;
            this.employee = employee;
        }

        public bool IsDone { get => isDone; set => isDone = value; }

        public void Update()
        {
            this.workRequired -= employee.WorkHoursPerWeek;
            if (this.workRequired <= 0 && !this.isDone)
            {
                if (JobDone != null)
                {
                    JobDone(this, new JobEventArgs(this));
                }
            }
        }

        public void OnJobDone(object sender,JobEventArgs e)
        {
            this.isDone = true;
            System.Console.WriteLine($"Job {this.name} done!");
        }

        public override string ToString()
        {
            return $"Job: {this.name} Hours Remaining: {this.workRequired}";
        }
    }
}
