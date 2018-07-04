namespace P03.DetailPrinter
{
    using P03.Detail_Printer;
    using System;
    using System.Collections.Generic;

    public class DetailsPrinter
    {
        private IList<IEmployee> employees;

        public DetailsPrinter(IList<IEmployee> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (Employee employee in this.employees)
            {
                this.PrintEmployee(employee);
            }
        }

        private void PrintEmployee(Employee employee)
        {
            Console.WriteLine(employee);
        }
    }
}
