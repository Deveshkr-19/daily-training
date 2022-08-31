using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    class ChildAdd : SumClass
    {
        public override int Add(int a, int b)
        {
            Console.WriteLine("The sum is:");
            return a + b;
        }
    }
}
