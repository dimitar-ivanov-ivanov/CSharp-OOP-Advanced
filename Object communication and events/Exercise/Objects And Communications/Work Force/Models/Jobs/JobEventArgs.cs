namespace Work_Force.Models.Jobs
{
    public class JobEventArgs
    {
        private Job job;

        public JobEventArgs(Job job)
        {
            this.job = job;
        }

        public Job Job
        {
            get { return this.Job; }
            set { this.job = value; }
        }
    }
}
