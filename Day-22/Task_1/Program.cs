using System;

namespace Task_1
{
    class Program
    {
        //Defining delegates of functions
        public delegate void addDelegate(int a, int b);
        public delegate string greetingsDelegate(string name);
        public void add(int x, int y)
        {
            Console.WriteLine("The sum of {0} and {1} is {2}", x, y, (x + y));
        }
        public static string Greetings(string name)
        {
            return "Hello " + name;
        }

        // Defining delegates
        public delegate double Addnumber1delegate(int no1, float no2, double no3);
        public delegate void Addnumber2delegate(int no1, float no2, double no3);
        public delegate bool checkLengthdelegate(string name);

        // Returning function
        public static double Addnumber1(int no1, float no2, double no3)
        {
            return no1 + no2 + no3;
        }
        // Printing function
        public static void Addnumber2(int no1, float no2, double no3)
        {
            Console.WriteLine(no1 + no2 + no3);
        }
        // Conditional returning function
        public static bool checkLength(string name)
        {
            if (name.Length > 4)
                return true;
            return false;
        }
        static void Main(string[] args)
        {
            Program obj = new Program();

            // Normal function calling
            obj.add(100, 200);
            string msg = Program.Greetings("Harsh");
            Console.WriteLine(msg);

            // Instantiating delegate (delegate takes function as an argument)
            addDelegate ad = new addDelegate(obj.add);
            greetingsDelegate gd = new greetingsDelegate(Program.Greetings);

            // Invoking delegate       
            ad(100, 200);
            msg = gd("Mahesh");
            Console.WriteLine(msg);

            // Instantiating delegates
            Addnumber1delegate obj1 = new Addnumber1delegate(Addnumber1);
            double result = obj1.Invoke(12, 125.25f, 91.42323);
            Console.WriteLine(result);

            Addnumber2delegate obj2 = new Addnumber2delegate(Addnumber2);
            obj2.Invoke(10, 12.5f, 43.2312);

            checkLengthdelegate obj3 = new checkLengthdelegate(checkLength);
            bool stat = obj3.Invoke("Devesh");
            Console.WriteLine(stat);

            // We can use this below code also, instead of defining and instantiating the generic delegates
            Func<int, float, double, double> funcObj = new Func<int, float, double, double>(Addnumber1);
            double res = funcObj.Invoke(10, 20.25f, 30.90);
            Console.WriteLine(res);

            Action<int, float, double> ActObj = new Action<int, float, double>(Addnumber2);
            ActObj.Invoke(10, 10.23f, 64.0);

            Predicate<string> preObj = new Predicate<string>(checkLength);
            bool status = preObj.Invoke("Devesh");
            Console.WriteLine(status);
        }
    }
}
