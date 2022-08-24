using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string cont = "Y";

            string roll_no = "", name = "", stu_class = "", email = "", mobile = "";
            int n;

            for (; cont.ToUpper() == "Y";)
            {

                Console.WriteLine("Press 1 to enter student details");
                Console.WriteLine("Press 2 to print student details");
                Console.WriteLine("Press 3 to check if the input is palindrome or not");
                Console.WriteLine("Press 4 to check if the input is an armstrong number or not");

                n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        Console.WriteLine("Enter the roll no. of the student: ");
                        roll_no = Console.ReadLine();
                        Console.WriteLine("Enter the name of the student: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter the class: ");
                        stu_class = Console.ReadLine();
                        Console.WriteLine("Enter the email: ");
                        email = Console.ReadLine();
                        Console.WriteLine("Enter the mobile no.: ");
                        mobile = Console.ReadLine();
                        break;

                    case 2:
                        Console.WriteLine("Roll number is " + roll_no);
                        Console.WriteLine("Name is " + name);
                        Console.WriteLine("Class is " + stu_class);
                        Console.WriteLine("E-mail is " + email);
                        Console.WriteLine("Mobile number is " + mobile);
                        break;

                    case 3:
                        Console.WriteLine("Enter the string: ");
                        string a = Console.ReadLine();
                        int i, j;
                        for (i = 0, j = a.Length - 1; i <= j; i++, j--)
                        {
                            if (a[i] != a[j])
                            {
                                Console.WriteLine("Input is not palindrome");
                                break;
                            }
                        }
                        if (i > j)
                            Console.WriteLine("Input is palindrome");
                        break;

                    case 4:
                        Console.WriteLine("Enter the number: ");
                        int num = int.Parse(Console.ReadLine());
                        int x = num, sum = 0;
                        for (; x > 0; x /= 10)
                        {
                            int temp = x % 10;
                            sum += (temp * temp * temp);
                        }
                        if (sum == num)
                            Console.WriteLine(num + " is an armstrong number.");
                        else
                            Console.WriteLine(num + " is not an armstrong number.");
                        break;

                    default:
                        Console.WriteLine("Wrong choice.");
                        break;
                }

                Console.WriteLine("Do you want to continue? (Y/N): ");
                cont = Console.ReadLine();
            }
        }
    }
}
