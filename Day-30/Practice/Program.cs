using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Sep_12
{
    public class cat
    {
        public void run()
        {
            Console.WriteLine("Paws");
        }
    }
    public class rat
    {
        public void run()
        {
            Console.WriteLine("Rodents");
        }
    }
    class user
    {
        public string name { get; set; }
        private string[] emailids = new string[10];
        public string contact { get; set; }

        public string this[int index]
        {
            get { return emailids[index]; }
            set { emailids[index] = value; }
        }
    }

    class employee
    {
        public string name { get; set; }
        public int age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LogInfo();


            cat c = new cat();
            rat r = new rat();
            common(c);
            common(r);


            BigInteger b = new BigInteger(9999999999999999999);


            var book = Tuple.Create("C# in depth", "Ajay", 350);
            Console.WriteLine("-------------------------------------------Book's Record-------------------------------------------");
            Console.WriteLine($"Title: {book.Item1}");
            Console.WriteLine($"Author: {book.Item2}");
            Console.WriteLine($"Price: {book.Item3}");


            // Multi argumented method
            var (name, email) = Show();
            Console.WriteLine($"{name} / {email}");


            var user = new user
            {
                [1] = "devesh@mail.com",
                [2] = "ajay@mail.com",
                [3] = "atul@mail.com",
                [4] = "abhay@mail.com",
                name = "Raghu@mail.com",
                contact = "4536345423246"
            };



            employee emp = null;
            //string employee = (emp != null) ? emp.name : null;
            string employee = emp?.name;
            Console.WriteLine(employee);


            sum(4, null);
        }
        static void sum(int x, int? y)
        {
            Console.WriteLine(x);
            Console.WriteLine(y);
        }
        static (string name, string email) Show()
        {
            return ("Devesh", "devesh@mail.com");
        }

        static void common(dynamic obj)
        {
            obj.run();
        }

        static void LogInfo([CallerMemberName] string methodName = "", [CallerLineNumberAttribute] int lineNo = 0, [CallerFilePath] string filePath = "")
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"Method name: {methodName}");
            Console.WriteLine($"Line number: {lineNo}");
            Console.WriteLine($"File path: {filePath}");
        }
    }
}
