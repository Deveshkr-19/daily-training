using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string repeat = "Y";
            while (repeat.ToUpper() == "Y")
            {
                Console.WriteLine("Press 1 for customer's details and 2 product's details:");
                int n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        Customers custObj = new Customers();
                        custObj.getCust();
                        custObj.showCust();
                        break;

                    case 2:
                        Products prodObj = new Products();
                        prodObj.getProd();
                        prodObj.showProd();
                        break;

                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }

                Console.WriteLine("Do you want to continue? (Y/N)");
                repeat = Console.ReadLine();
            }
        }
    }
}
