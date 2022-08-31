using System;
using PartialLib;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Method Overloading
            SumClass addObj = new SumClass();

            Console.WriteLine("Adding two integers using add function:\n" + addObj.Add(3, 9));
            Console.WriteLine("Adding three integers using add function:\n" + addObj.Add(6, 12, 4));

            // Method Overriding
            ChildAdd childObj = new ChildAdd();

            Console.WriteLine("Adding two integers using add function of the child class:");
            Console.WriteLine(childObj.Add(3, 9));

            // Partial Classes

            Partial bookObj = new Partial("Harry Potter", "J. K. Rowling");

            bookObj.displayBookDetails();

            // Access Specifiers

            AccessSpecifiers accObj = new AccessSpecifiers();

            Console.WriteLine("Enter 2 numbers for the public variables:");
            accObj.pubA = int.Parse(Console.ReadLine());
            accObj.pubB = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a number for the protected variable:");
            accObj.getProtA = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter a number for the private variable:");
            accObj.getPrivA = int.Parse(Console.ReadLine());

            Console.WriteLine("Numbers you entered for the public variables are: " + accObj.pubA + " & " + accObj.pubB);
            Console.WriteLine("Numbers you entered for the protected variable is: " + accObj.getProtA);
            Console.WriteLine("Numbers you entered for the private variable is: " + accObj.getPrivA);


        }
    }
}
