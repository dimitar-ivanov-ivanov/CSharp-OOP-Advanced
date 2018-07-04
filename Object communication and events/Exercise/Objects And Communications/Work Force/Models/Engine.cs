using System;
using System.Collections.Generic;
using System.Linq;
using Work_Force.Models.Employees;
using Work_Force.Models.Jobs;

namespace Work_Force.Models
{
    public class Engine
    {
        private const string TerminatingCommand = "End";

        public delegate void JobDoneEventHandler(object sender, JobEventArgs e);

        public void Run()
        {
            var input = Console.ReadLine();
            var jobs = new JobList();
            var employees = new List<Employee>();

            while(input != TerminatingCommand)
            {
                var args = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (args[0])
                {
                    case "Job":
                        var name = args[1];
                        var hours = int.Parse(args[2]);
                        var employee = employees.FirstOrDefault(e => e.Name == args[3]);
                        Job job = new Job(name, hours, employee);

                        job.JobDone += job.OnJobDone;
                        jobs.Add(job);
                        break;
                    case "StandardEmployee":
                        name = args[1];
                        employees.Add(new StandartEmployee(name));
                        break;
                    case "PartTimeEmployee":
                        name = args[1];
                        employees.Add(new PartTimeEmployee(name));
                        break;
                    case "Pass":
                        jobs.ForEach(j => j.Update());
                        break;
                    case "Status":
                        foreach (var j in jobs)
                        {
                            if (!j.IsDone)
                            {
                                Console.WriteLine(j.ToString());
                            }
                        }
                        break;
                }

                input = Console.ReadLine();
            }
        }
    }
}
