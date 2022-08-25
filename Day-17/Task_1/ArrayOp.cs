using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    class ArrayOp
    {
        public ArrayOp()
        {
            Console.WriteLine("Object has been created");
        }

        public void print_array(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public void area(int x, int y)
        {
            Console.WriteLine(x * y);
        }

        public void area(double r)
        {
            Console.WriteLine(2 * 3.14 * r);
        }
    }
}
