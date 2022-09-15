using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations opObj = new Operations();
            Console.WriteLine(opObj.fact(1));
            Console.WriteLine(opObj.isPrime(2));
        }
    }
}
