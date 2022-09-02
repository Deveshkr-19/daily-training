using AddClass;
using System;

namespace Task_1
{
    class Program
    {
        static void addVal(int a, int b, int sum)
        {
            sum = a + b;
            Console.WriteLine(sum);
        }
        static void addRef(AddCls obj)
        {
            obj.total = obj.x + obj.y;
            Console.WriteLine(obj.total);
        }


        static void Main(string[] args)
        {
            AddCls addObj = new AddCls(11, 8);

            addVal(addObj.x, addObj.y, addObj.total);
            Console.WriteLine(addObj.total);

            addRef(addObj);
            Console.WriteLine(addObj.total);

            addObj = -addObj;
            Console.WriteLine(addObj.diff);
        }
    }
}
