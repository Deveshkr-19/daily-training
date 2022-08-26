using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    class Products : Iproducts
    {
        public int prodID, quantity, price;
        public string prodName, brand;
        public void getProd()
        {
            Console.WriteLine("Please enter the product details:");
            this.prodID = int.Parse(Console.ReadLine());
            this.prodName = Console.ReadLine();
            this.brand = Console.ReadLine();
            this.quantity = int.Parse(Console.ReadLine());
            this.price = int.Parse(Console.ReadLine());
        }
        public void showProd()
        {
            Console.WriteLine("Here are the details you entered");
            Console.WriteLine(this.prodID);
            Console.WriteLine(this.prodName);
            Console.WriteLine(this.brand);
            Console.WriteLine(this.quantity);
            Console.WriteLine(this.price);
        }
    }
}
