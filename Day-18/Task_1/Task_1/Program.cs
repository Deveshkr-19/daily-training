using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 for customer's details and 2 product's details:");
            int n = int.Parse(Console.ReadLine());

            switch(n)
            {
                case 1:
                    Customers custObj = new Customers();
                    Console.WriteLine("Please enter the customer details:");
                    custObj.custID = int.Parse(Console.ReadLine());
                    custObj.name = Console.ReadLine();
                    custObj.gender = Console.ReadLine();
                    custObj.showDetails();
                    break;
                case 2:
                    Products prodObj = new Products();
                    Console.WriteLine("Please enter the product details:");
                    prodObj.prodID = int.Parse(Console.ReadLine());
                    prodObj.prodName = Console.ReadLine();
                    prodObj.brand = Console.ReadLine();
                    prodObj.quantity = int.Parse(Console.ReadLine());
                    prodObj.showDetails();
                    break;
            }
        }
    }
}
