using System;

namespace Task_2
{
    class account
    {
        public int acc_no;
        public string name;
        public static float roi = 8.8f;

        public account(int acc_no, string name)
        {
            this.acc_no = acc_no;
            this.name = name;
        }

        public void display()
        {
            Console.WriteLine(acc_no + " / " + name + " / " + roi);
        }
    }

    public static class myMath
    {
        public static float pi = 3.14f;
        public static int cube(int n)
        {
            return n * n * n;
        }
    }

    public struct employee
    {
        public int id;
        public string name;
        public double salary;
        public string gender;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initilization using Constructor
            account acc1 = new account(122, "Devesh");
            acc1.display();
            account acc2 = new account(114, "Nupur");
            acc2.display();
            account acc3 = new account(197, "Atul");
            acc3.display();

            Console.WriteLine();

            // Usage of static class and its members
            Console.WriteLine("Value of Pi is: " + myMath.pi);
            Console.WriteLine("Cube of 3 is: " + myMath.cube(3));

            Console.WriteLine();

            // Use of structure
            employee[] emp = new employee[5];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter the employee id:");
                emp[i].id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the employee name:");
                emp[i].name = Console.ReadLine();
                Console.WriteLine("Enter the employee salary:");
                emp[i].salary = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the employee gender:");
                emp[i].gender = Console.ReadLine();
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(emp[i].id + " / " + emp[i].name + " / " + emp[i].salary + " / " + emp[i].gender);
            }
        }
    }
}
