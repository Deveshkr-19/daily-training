using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1
{
    public class Operations : IOperations
    {
        public double fact(int n)
        {
            if(n < 0)
                throw new ArgumentOutOfRangeException($"{n} is less than zero.");
            else if (n < 2)
                return 1;

            return n * fact(n - 1);
        }

        public bool isPrime(int n)
        {
            if(n < 0)
                throw new ArgumentOutOfRangeException($"{n} is less than zero.");
            else if(n <= 1)
                return false;
            else
                for (int i = 2; i * i <= n; i++)
                    if (n % i == 0)
                        return false;
            return true;
        }
    }
}
