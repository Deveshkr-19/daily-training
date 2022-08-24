using System;
using System.Collections.Generic;
using System.Text;

namespace Teacher
{
    public class Teachers
    {
        public string name { get; set; }
        public int teachID { get; set; }
        public string subject { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }

        public void show()
        {
            Console.WriteLine(teachID+ " / " + name + " / " + subject + " / " + email + " / " + mobile);
        }
    }
}
