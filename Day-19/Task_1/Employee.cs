using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    public class Employee
    {
        public int empid { get; set; }
        public string name { get; set; }
        public string mobile { get; set; }
        private double salary { get; set; }
        protected string email { get; set; }

        public double getsalary
        {
            get
            {
                return salary;
            }
            set
            {
                salary = value;
            }
        }
    }
}
