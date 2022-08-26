using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    class Customers : Icommon
    {
        public int custID;
        public string name, gender;

        public void showDetails()
        {
            Console.WriteLine("Here are the details you entered");
            Console.WriteLine(this.custID);
            Console.WriteLine(this.name);
            Console.WriteLine(this.gender);
        }
    }
}
