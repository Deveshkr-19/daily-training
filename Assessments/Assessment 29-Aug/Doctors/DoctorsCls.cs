using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Doctors
{
    public class DoctorsCls : CommonCls
    {
        public string specialization;
        private int salary;
        protected string address;

        // Accessing private member
        public int getSalary
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

        // Accessing protected member

        public string getAddress
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

    }
}
