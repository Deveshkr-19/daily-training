using System;
using System.Collections.Generic;
using Task_1.SampleClasses;

namespace Task_1
{
    class Program : Employee
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();

            Console.WriteLine("Enter ID, name, mobile");
            emp.empid = int.Parse(Console.ReadLine());
            emp.name = Console.ReadLine();
            emp.mobile = Console.ReadLine();

            Console.WriteLine("\nDetails entered by you:\nID: " + emp.empid + ", Name: " + emp.name + ", Mobile No.: " + emp.mobile);

            // We can get salary by using the getter and setter
            emp.getsalary = 30000;
            Console.WriteLine("\nSalary: " + emp.getsalary);

            // We can access the protected member by inheriting the employee class
            Program progObj = new Program();
            Console.WriteLine("\nEnter email:");
            progObj.email = Console.ReadLine();
            Console.WriteLine(progObj.email);


            //list and forEach loop
            List<int> numbers = new List<int>()
            {
                535,213,56,230,60,76,98,55,770,96,28,122
            };



            Console.WriteLine("\nEven numbers are: ");
            List<int> evennumbers = numbers.FindAll(x => (x % 2) == 0);
            foreach (var value in evennumbers)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();



            Console.WriteLine("\nOdd numbers are: ");
            List<int> oddnumbers = numbers.FindAll(x => (x % 2) != 0);
            foreach (var value in oddnumbers)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();


            Console.WriteLine("\nNumbers multiple of 5: ");
            List<int> mul5 = numbers.FindAll(x => (x % 5) == 0);
            foreach (var value in mul5)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();


            List<Student> stu = new List<Student>
            {
                new Student { studID = int.Parse(Console.ReadLine()), name = "Devesh", age = 23, standard = 9, mobile = "654324453" },
                new Student { studID = 102, name = "Diksha", age = 24, standard = 11, mobile = "665324453" },
                new Student { studID = 103, name = "Deepak", age = 26, standard = 10, mobile = "654369853" },
                new Student { studID = 104, name = "Deepesh", age = 21, standard = 9, mobile = "657234453" },
                new Student { studID = 105, name = "Devyansh", age = 26, standard = 11, mobile = "654320523" },
            };

            Console.WriteLine();


            foreach (Student stud in stu)
            {
                Console.WriteLine(stud.studID + " / " + stud.name + " / " + stud.age + " / " + stud.standard + " / " + stud.mobile);
            }

            // Using partial classes
            Sample mov = new Sample("\nThor 4", 2022);
            mov.displayMovieDetails();
        }
    }
}
