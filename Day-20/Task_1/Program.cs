using System;
using System.Data;
using System.Data.SqlClient;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string repeat = "Y";

            while (repeat.ToUpper() == "Y")
            {

                Console.WriteLine("Enter 1 for insertion\nEnter2 for deletion\nEnter 3 for updation\nEnter 4 for searching:");
                int choice = int.Parse(Console.ReadLine());

                Employee emp = new Employee();

                // Connection strings
                SqlConnection con = new SqlConnection("server=localhost;database=EmployeeDB;integrated security=true");

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the id of employee");
                        emp.id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the name of employee");
                        emp.name = Console.ReadLine();
                        Console.WriteLine("Enter the department of employee");
                        emp.department = Console.ReadLine();
                        Console.WriteLine("Enter the salary of employee");
                        emp.salary = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the gender of employee");
                        emp.gender = Console.ReadLine();

                        // Command creation
                        SqlCommand cmd = new SqlCommand("insert into Employee values(" + emp.id + ", '" + emp.name + "', '" + emp.department + " ', " + emp.salary + ",'" + emp.gender + "')", con);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Console.WriteLine("Record inserted successfully!");

                        break;

                    case 2:
                        Console.WriteLine("Enter ID of the employee which is to be deleted:");
                        emp.id = int.Parse(Console.ReadLine());

                        // Command creation
                        SqlCommand delCmd = new SqlCommand("delete from Employee where id = " + emp.id + " ", con);

                        con.Open();
                        delCmd.ExecuteNonQuery();
                        con.Close();
                        Console.WriteLine("Record deleted successfully!");

                        break;

                    case 3:
                        Console.WriteLine("Enter id of employee to be updated");
                        emp.id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the name of employee");
                        emp.name = Console.ReadLine();
                        Console.WriteLine("Enter the department of employee");
                        emp.department = Console.ReadLine();
                        Console.WriteLine("Enter the salary of employee");
                        emp.salary = double.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the gender of employee");
                        emp.gender = Console.ReadLine();

                        // Command creation
                        SqlCommand updCmd = new SqlCommand("update Employee set name = '" + emp.name + "', department = '" + emp.department + "', salary = " + emp.salary + ", gender = '" + emp.gender + "' where id = " + emp.id, con);

                        con.Open();
                        updCmd.ExecuteNonQuery();
                        con.Close();
                        Console.WriteLine("Record updated successfully!");

                        break;

                    case 4:
                        Console.WriteLine("Enter id of employee to be searched");
                        emp.id = int.Parse(Console.ReadLine());
                        SqlDataAdapter da = new SqlDataAdapter("select * from Employee", con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "Employee");
                        int x = ds.Tables[0].Rows.Count;

                        for (int i = 0; i < x; i++)
                        {
                            if (emp.id.ToString() == ds.Tables[0].Rows[i][0].ToString())
                            {
                                Console.WriteLine("Name: " + ds.Tables[0].Rows[i][1].ToString());
                                Console.WriteLine("Department: " + ds.Tables[0].Rows[i][2].ToString());
                                Console.WriteLine("Salary: " + ds.Tables[0].Rows[i][3].ToString());
                                Console.WriteLine("Gender: " + ds.Tables[0].Rows[i][4].ToString());
                            }
                        }

                        break;
                }

                Console.WriteLine("Do you want to continue? (Y/N)");
                repeat = Console.ReadLine();
            }
        }
    }
    
}
