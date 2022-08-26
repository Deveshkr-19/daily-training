using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    class Products : Icommon
    {
        public int prodID, quantity;
        public string prodName, brand;
        public void showDetails()
        {
            Console.WriteLine("Here are the details you entered");
            Console.WriteLine(this.prodID);
            Console.WriteLine(this.prodName);
            Console.WriteLine(this.brand);
            Console.WriteLine(this.quantity);
        }
    }
}
