using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connection strings
            SqlConnection con = new SqlConnection("server=localhost;database=EmployeeDB;integrated security=true");

            string empFile = @"C:\training\daily-training\Day-28\Task_1\employees.txt";

            Employee emp = new Employee();

            string repeat = "Y";
            while (repeat.ToUpper() == "Y")
            {
                Console.WriteLine("\nEnter the id of the employee");
                emp.id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the name of the employee");
                emp.name = Console.ReadLine();
                Console.WriteLine("Enter the department of the employee");
                emp.department = Console.ReadLine();
                Console.WriteLine("Enter the salary of the employee");
                emp.salary = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter the gender of the employee");
                emp.gender = Console.ReadLine();

                // Command creation
                SqlCommand insCmd = new SqlCommand("insert into Employee values(" + emp.id + ", '" + emp.name + "', '" + emp.department + "', " + emp.salary + ",'" + emp.gender + "')", con);

                con.Open();
                insCmd.ExecuteNonQuery();
                con.Close();

                if(!File.Exists(empFile))
                    using (StreamWriter sw = File.CreateText(empFile))
                    {
                        sw.WriteLine($"{emp.id} / {emp.name} / {emp.department} / {emp.salary} / {emp.gender}");
                    }
                else
                    using (StreamWriter sw = File.AppendText(empFile))
                    {
                        sw.WriteLine($"{emp.id} / {emp.name} / {emp.department} / {emp.salary} / {emp.gender}");
                    }

                Console.WriteLine("\n\nHere are the updated records:\n");

                using (StreamReader sr = File.OpenText(empFile))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }


                Console.WriteLine("Do you want to start again? (Y/N)");
                repeat = Console.ReadLine();
            }
        }
    }
}
