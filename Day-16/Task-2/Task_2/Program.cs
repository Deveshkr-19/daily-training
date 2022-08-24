using System;
using Student;
using Teacher;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string rep = "Y";
            for (; rep.ToUpper() == "Y";)
            {
                Console.WriteLine("Press 1 to input and display students details");
                Console.WriteLine("Press 2 to input and display teachers details");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Students stu = new Students();

                        Console.WriteLine("Enter student ID:");
                        stu.stuID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter student name:");
                        stu.name = Console.ReadLine();
                        Console.WriteLine("Enter student branch:");
                        stu.branch = Console.ReadLine();
                        Console.WriteLine("Enter student email:");
                        stu.email = Console.ReadLine();
                        Console.WriteLine("Enter student mobile:");
                        stu.mobile = Console.ReadLine();

                        stu.show();
                        break;

                    case 2:
                        Teachers teacher = new Teachers();

                        Console.WriteLine("Enter teacher ID:");
                        teacher.teachID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter teacher name:");
                        teacher.name = Console.ReadLine();
                        Console.WriteLine("Enter teacher subject:");
                        teacher.subject = Console.ReadLine();
                        Console.WriteLine("Enter teacher email:");
                        teacher.email = Console.ReadLine();
                        Console.WriteLine("Enter teacher mobile:");
                        teacher.mobile = Console.ReadLine();

                        teacher.show();
                        break;

                    default:
                        Console.WriteLine("Wrong choice.");
                        break;
                }
                Console.WriteLine("Do you want to continue? (Y/N)");
                rep = Console.ReadLine();
            }

        }
    }
}
