using System;
using System.Collections.Generic;
using System.Text;

namespace Student
{
    public class Students
    {
        public string name { get; set; }
        public int stuID { get; set; }
        public string branch { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }

        public void show()
        {
            Console.WriteLine(stuID + " / " + name + " / " + branch + " / " + email + " / " + mobile);
        }
    }
}
