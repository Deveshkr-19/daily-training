using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    public class SumClass
    {
        // Method Overloading

        // adding two values.
        public virtual int Add(int a, int b)
        {
            return a + b;
        }

        // adding three values.
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
