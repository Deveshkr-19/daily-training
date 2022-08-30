using System;
using System.Data;
using System.Data.SqlClient;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter you ID and password.");
            int loginID = int.Parse(Console.ReadLine());
            string pass = Console.ReadLine();


            // Connection strings
            SqlConnection con = new SqlConnection("server=localhost;database=bank_db;integrated security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from login", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Admin");
            int loginCount = ds.Tables[0].Rows.Count;

            for(int i = 0; i < loginCount; i++)
            {
                if(loginID.ToString() == ds.Tables[0].Rows[i][0].ToString())
                {
                    if(pass.ToString() == ds.Tables[0].Rows[i][1].ToString())
                    {
                        Console.WriteLine("Successfully logged in!\n");

                        string repeat = "Y";
                        while(repeat.ToUpper() == "Y")
                        {
                            Console.WriteLine("Enter 1 for insertion\nEnter 2 for deletion\nEnter 3 for updation\nEnter 4 for printing all values:");
                            int choice = int.Parse(Console.ReadLine());

                            Customers cust = new Customers();

                            switch(choice)
                            {
                                case 1:
                                    Console.WriteLine("Enter the name of customer");
                                    cust.name = Console.ReadLine();
                                    Console.WriteLine("Enter the age of customer");
                                    cust.age = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the address of customer");
                                    cust.address = Console.ReadLine();
                                    Console.WriteLine("Enter the mobile number of customer");
                                    cust.phone = Console.ReadLine();
                                    Console.WriteLine("Enter the email of customer");
                                    cust.email = Console.ReadLine();

                                    // Command creation
                                    SqlCommand insCmd = new SqlCommand("insert into CustomerDetails values('" + cust.name + "', " + cust.age + ", '" + cust.address + " ', '" + cust.phone + "','" + cust.email + "')", con);

                                    con.Open();
                                    insCmd.ExecuteNonQuery();
                                    con.Close();
                                    Console.WriteLine("Record inserted successfully!");

                                    break;

                                case 2:
                                    Console.WriteLine("Enter ID of the customer which is to be deleted:");
                                    cust.id = int.Parse(Console.ReadLine());

                                    // Command creation
                                    SqlCommand delCmd = new SqlCommand("delete from CustomerDetails where custId = " + cust.id + " ", con);

                                    con.Open();
                                    delCmd.ExecuteNonQuery();
                                    con.Close();
                                    Console.WriteLine("Record deleted successfully!");

                                    break;

                                case 3:
                                    Console.WriteLine("Enter id of customer to be updated");
                                    cust.id = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Enter the name of customer");
                                    cust.name = Console.ReadLine();
                                    Console.WriteLine("Enter the age of customer");
                                    cust.age = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the address of customer");
                                    cust.address = Console.ReadLine();
                                    Console.WriteLine("Enter the mobile number of customer");
                                    cust.phone = Console.ReadLine();
                                    Console.WriteLine("Enter the email of customer");
                                    cust.email = Console.ReadLine();

                                    // Command creation
                                    SqlCommand updCmd = new SqlCommand("update CustomerDetails set name = '" + cust.name + "', age = " + cust.age + ", address = '" + cust.address + " ', phone = '" + cust.phone + "', email = '" + cust.email + "' where custId = " + cust.id, con);

                                    con.Open();
                                    updCmd.ExecuteNonQuery();
                                    con.Close();
                                    Console.WriteLine("Record updated successfully!");

                                    break;

                                case 4:
                                    SqlDataAdapter custDA = new SqlDataAdapter("select * from CustomerDetails", con);
                                    custDA.Fill(ds, "Customers");
                                    int custCount = ds.Tables[1].Rows.Count;

                                    for(int j = 0; j < custCount; j++)
                                    {
                                        Console.Write("ID: " + ds.Tables[1].Rows[j][0].ToString());
                                        Console.Write(", Name: " + ds.Tables[1].Rows[j][1].ToString());
                                        Console.Write(", Age: " + ds.Tables[1].Rows[j][2].ToString());
                                        Console.Write(", Address: " + ds.Tables[1].Rows[j][3].ToString());
                                        Console.Write(", Phone: " + ds.Tables[1].Rows[j][4].ToString());
                                        Console.Write(", Email: " + ds.Tables[1].Rows[j][5].ToString());
                                        Console.WriteLine("\n");
                                    }

                                    break;

                                default:

                                    break;
                            }

                            Console.WriteLine("Do you want to start again? (Y/N)");
                            repeat = Console.ReadLine();
                        }

                    }
                    else
                    {
                        Console.WriteLine("wrond pass");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong ID");
                }
            }


        }
    }
}
