using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 10, 23, 45, 12, 65 };
            int[] arrA = new int[arr.Length];
            ArrayOp arrObj = new ArrayOp();

            arrObj.print_array(arr);

            Array.Sort(arr);
            arrObj.print_array(arr);

            Array.Reverse(arr);
            arrObj.print_array(arr);

            Array.Copy(arr, arrA, arr.Length);
            arrObj.print_array(arr);

            int l = 5, b = 3;
            double r = 8;

            arrObj.area(l, b);
            arrObj.area(r);
        }
    }
}
