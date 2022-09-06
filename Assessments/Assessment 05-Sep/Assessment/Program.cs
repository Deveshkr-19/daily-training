using EmployeeCls;
using FranchiseCls;
using OrdersCls;
using System;
using System.Data;
using System.Data.SqlClient;
using UsersCls;

namespace Assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your ID and password.");
            string loginID = Console.ReadLine();
            string pass = Console.ReadLine();

            bool loggedIn = false;


            // Connection strings
            SqlConnection con = new SqlConnection("server=localhost;database=franchise_db;integrated security=true");

            SqlDataAdapter da = new SqlDataAdapter("select * from login", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Login");
            int loginCount = ds.Tables["Login"].Rows.Count;

            if(loginID == ds.Tables["Login"].Rows[0][0].ToString())         // Admin Login
            {
                if (pass == ds.Tables["Login"].Rows[0][1].ToString())
                {
                    loggedIn = true;
                    Console.WriteLine("Admin logged in successfully!");

                    string repeat = "Y";
                    while (repeat.ToUpper() == "Y")
                    {
                        Console.WriteLine("Enter 1 to register a franchise\n" +
                            "Enter 2 to get franchise details\n" +
                            "Enter 3 to get sales record for a franchise\n" +
                            "Enter 4 to get total sales");
                        
                        int choice = int.Parse(Console.ReadLine());
                        switch(choice)
                        {
                            case 1:
                                FranchiseClass franchise = new FranchiseClass();
                                UsersClass f_manager = new UsersClass();

                                Console.WriteLine("Enter the franchise ID for the new franchise");
                                franchise.f_id = Console.ReadLine();

                                Console.WriteLine("Enter the location for the new franchise");
                                franchise.location = Console.ReadLine();

                                Console.WriteLine("Enter the area in sq. ft. for the new franchise");
                                franchise.area = int.Parse(Console.ReadLine());

                                Console.WriteLine("Enter the email of the store manager for the new franchise");
                                franchise.m_email = Console.ReadLine();

                                Console.WriteLine("Enter the mobile no. of the store manager for the new franchise");
                                franchise.m_mobile = Console.ReadLine();

                                Console.WriteLine("Create a password for the franchise manager");
                                f_manager.password = Console.ReadLine();

                                // Command creation
                                SqlCommand insCmd = new SqlCommand("insert into franchise(" +
                                    "franchise_id, location, area, manager_email, manager_mobile) values('" + 
                                    franchise.f_id + "', '" + franchise.location + "', " + franchise.area 
                                    + ", '" + franchise.m_email + "', '" + franchise.m_mobile + "')", con);

                                SqlCommand insPassCmd = new SqlCommand("insert into login values ('"
                                    + franchise.f_id + "', '" + f_manager.password + "')", con);

                                con.Open();
                                insCmd.ExecuteNonQuery();
                                insPassCmd.ExecuteNonQuery();
                                con.Close();
                                Console.WriteLine("Record inserted successfully!");

                                break;

                            case 2:
                                Console.WriteLine("Enter the franchise ID whose details you want to print:");
                                string fID = Console.ReadLine();


                                if (ds.Tables.CanRemove(ds.Tables[fID + " Details"]))
                                    ds.Tables.Remove(ds.Tables[fID + " Details"]);

                                SqlDataAdapter da2 = new SqlDataAdapter("select * from franchise where franchise_id = '" + fID + "'", con);
                                da2.Fill(ds, fID + " Details");
                                int fRowCount = ds.Tables[fID + " Details"].Rows.Count;
                                int fColCount = ds.Tables[fID + " Details"].Columns.Count;

                                if (fRowCount == 0)
                                    Console.WriteLine("No Data Found!");
                                else
                                {
                                    Console.WriteLine();
                                    for (int j = 0; j < fRowCount; j++)
                                    {
                                        for (int k = 0; k < fColCount; k++)
                                        {
                                            Console.Write(ds.Tables[fID + " Details"].Columns[k] + ": "
                                                + ds.Tables[fID + " Details"].Rows[j][k].ToString() + "\n");
                                        }
                                    }
                                }

                                break;

                            case 3:
                                Console.WriteLine("Enter the franchise ID whose sales record you want to print:");
                                fID = Console.ReadLine();

                                Console.WriteLine("Enter the date for which you want to see the sales in dd-MM-yyyy format:");
                                string inpDate = Console.ReadLine();

                                if (ds.Tables.CanRemove(ds.Tables[fID + " Order Details"]))
                                    ds.Tables.Remove(ds.Tables[fID + " Order Details"]);

                                SqlDataAdapter da3 = new SqlDataAdapter("select o.order_id as 'Order ID', o.order_method as 'Order Method', " +
                                            "o.order_type as 'Order Type', o.item as 'Item Name', o.empID as 'Employee ID', " +
                                            "o.amount as Amount, o.date as Date, e.franchise_id as 'Franchise ID' " +
                                            "from orders o " +
                                            "inner join employees e on o.empID = e.empID " +
                                            "where e.franchise_id = '" + fID + "' " +
                                            "and o.date = '" + inpDate + "'", con);
                                da3.Fill(ds, fID + " Order Details");
                                int orderRowCount = ds.Tables[fID + " Order Details"].Rows.Count;
                                int orderColCount = ds.Tables[fID + " Order Details"].Columns.Count;

                                if (orderRowCount == 0)
                                {
                                    Console.WriteLine("No data found!");
                                }
                                else
                                {
                                    Console.WriteLine();
                                    for (int j = 0; j < orderRowCount; j++)
                                    {
                                        for (int k = 0; k < orderColCount; k++)
                                        {
                                            Console.Write(ds.Tables[fID + " Order Details"].Columns[k] + ": "
                                                + ds.Tables[fID + " Order Details"].Rows[j][k].ToString() + "\n");
                                        }
                                        Console.WriteLine();
                                    }
                                }

                                break;

                            case 4:
                                Console.WriteLine("Enter the date for which you want to see the sales in dd-MM-yyyy format:");
                                inpDate = Console.ReadLine();

                                if (ds.Tables.CanRemove(ds.Tables["Total Sales"]))
                                    ds.Tables.Remove(ds.Tables["Total Sales"]);

                                SqlDataAdapter da4 = new SqlDataAdapter("select e.franchise_id as 'Franchise ID', " +
                                    "sum(o.amount) as Total from orders as o inner join employees as e " +
                                    "on o.empID = e.empID where o.date = '" + inpDate + "' group by e.franchise_id", con);
                                da4.Fill(ds, "Total Sales");

                                int salesRowCount = ds.Tables["Total Sales"].Rows.Count;
                                int salesColCount = ds.Tables["Total Sales"].Columns.Count;

                                if (salesRowCount == 0)
                                {
                                    Console.WriteLine("No data found!");
                                }
                                else
                                {
                                    Console.WriteLine();
                                    for (int j = 0; j < salesRowCount; j++)
                                    {
                                        for (int k = 0; k < salesColCount; k++)
                                        {
                                            Console.Write(ds.Tables["Total Sales"].Columns[k] + ": "
                                                + ds.Tables["Total Sales"].Rows[j][k].ToString() + "\n");
                                        }
                                        Console.WriteLine();
                                    }
                                }

                                break;

                            default:
                                Console.WriteLine("Incorrect Choice");

                                break;
                        }


                        Console.WriteLine("Do you want to start again? (Y/N)");
                        repeat = Console.ReadLine();
                    }
                }
            }
            else
            {
                for(int i = 1; i < loginCount; i++)
                {
                    if(loginID == ds.Tables["Login"].Rows[i][0].ToString())         // Franchise Login
                    {
                        if (pass == ds.Tables["Login"].Rows[i][1].ToString())
                        {
                            loggedIn = true;
                            Console.WriteLine("Franchise manager logged in successful!");

                            string repeat = "Y";
                            while (repeat.ToUpper() == "Y")
                            {
                                Console.WriteLine("Enter 1 to register an employee\n" +
                                    "Enter 2 to insert orders\n" +
                                    "Enter 3 to distribute salaries\n" +
                                    "Enter 4 to get sales record\n" +
                                    "Enter 5 to get records for either online or offline sales");

                                int choice = int.Parse(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1:
                                        EmployeeClass emp = new EmployeeClass();

                                        Console.WriteLine("Enter the name of the new employee");
                                        emp.name = Console.ReadLine();

                                        Console.WriteLine("Enter the email of the new employee");
                                        emp.email = Console.ReadLine();

                                        Console.WriteLine("Enter the mobile no. of the new employee");
                                        emp.mobile = Console.ReadLine();

                                        // Command creation
                                        SqlCommand insEmpCmd = new SqlCommand("insert into employees values ('" 
                                            + emp.name + "', '" + loginID + "', '" + emp.email 
                                            + "', '" + emp.mobile + "')", con);

                                        con.Open();
                                        insEmpCmd.ExecuteNonQuery();
                                        con.Close();
                                        Console.WriteLine("Record inserted successfully!");

                                        break;

                                    case 2:
                                        OrdersClass ord = new OrdersClass();

                                        Console.WriteLine("Enter the method of order: (Online/Offline)");
                                        ord.o_method = Console.ReadLine();

                                        Console.WriteLine("Enter the type of order: (Dine in/Takeout)");
                                        ord.o_type = Console.ReadLine();

                                        Console.WriteLine("Enter the item name to order:");
                                        ord.item = Console.ReadLine();

                                        Console.WriteLine("Enter the ID of the employee taking the order:");
                                        ord.empID = int.Parse(Console.ReadLine());

                                        Console.WriteLine("Enter the amount of the order:");
                                        ord.amount = int.Parse(Console.ReadLine());

                                        string currDate = DateTime.Now.ToString("dd/MM/yyyy");
                                        Console.WriteLine(currDate);

                                        // Command creation
                                        SqlCommand insOrdCmd = new SqlCommand("insert into orders values ('"
                                            + ord.o_method + "', '" + ord.o_type + "', '" + ord.item + "', "
                                            + ord.empID + ", " + ord.amount + ", '" + currDate + "')", con);

                                        con.Open();
                                        insOrdCmd.ExecuteNonQuery();
                                        con.Close();
                                        Console.WriteLine("Record inserted successfully!");

                                        break;

                                    case 3:
                                        // Command creation
                                        SqlCommand updSalCmd = new SqlCommand("update franchise set " +
                                            "salaries_dist = salaries_dist + 1 where franchise_id = '" 
                                            + loginID + "'", con);

                                        con.Open();
                                        updSalCmd.ExecuteNonQuery();
                                        con.Close();
                                        Console.WriteLine("Salaries distributed for this month!");

                                        break;

                                    case 4:
                                        Console.WriteLine("Enter the date for which you want to see the sales in dd-MM-yyyy format:");
                                        string inpDate = Console.ReadLine();

                                        if (ds.Tables.CanRemove(ds.Tables["F_Order_Details"]))
                                            ds.Tables.Remove(ds.Tables["F_Order_Details"]);

                                        SqlDataAdapter da1 = new SqlDataAdapter("select o.order_id as 'Order ID', o.order_method as 'Order Method', " +
                                            "o.order_type as 'Order Type', o.item as 'Item Name', o.empID as 'Employee ID', " +
                                            "o.amount as Amount, o.date as Date, e.franchise_id as 'Franchise ID' " +
                                            "from orders o " +
                                            "inner join employees e on o.empID = e.empID " +
                                            "where e.franchise_id = '" + loginID + "' " +
                                            "and o.date = '" + inpDate + "'", con);

                                        da1.Fill(ds, "F_Order_Details");
                                        int orderRowCount = ds.Tables["F_Order_Details"].Rows.Count;
                                        int orderColCount = ds.Tables["F_Order_Details"].Columns.Count;

                                        if (orderRowCount == 0)
                                        {
                                            Console.WriteLine("No data found!");
                                        }
                                        else
                                        {
                                            Console.WriteLine();
                                            for (int j = 0; j < orderRowCount; j++)
                                            {
                                                for (int k = 0; k < orderColCount; k++)
                                                {
                                                    Console.Write(ds.Tables["F_Order_Details"].Columns[k] + ": " 
                                                        + ds.Tables["F_Order_Details"].Rows[j][k].ToString() + "\n");
                                                }
                                                Console.WriteLine();
                                            }
                                        }

                                        break;

                                    case 5:
                                        Console.WriteLine("Enter 1 to get online sales for your franchise or 2 to get offline sales for your franchise");
                                        int o_sales = int.Parse(Console.ReadLine());

                                        if (ds.Tables.CanRemove(ds.Tables["Online Sales"]))
                                            ds.Tables.Remove(ds.Tables["Online Sales"]);

                                        switch (o_sales)
                                        {
                                            case 1:
                                                SqlDataAdapter da5 = new SqlDataAdapter("select o.order_id as 'Order ID', o.order_method as 'Order Method', " +
                                                    "o.order_type as 'Order Type', o.item as 'Item Name', o.empID as 'Employee ID', " +
                                                    "o.amount as Amount, o.date as Date, e.franchise_id as 'Franchise ID' " +
                                                    "from orders o " +
                                                    "inner join employees e on o.empID = e.empID " +
                                                    "where e.franchise_id = '" + loginID + "' " +
                                                    "and o.order_method = 'Online'", con);

                                                da5.Fill(ds, "Online Sales");
                                                int salesRowCount = ds.Tables["Online Sales"].Rows.Count;
                                                int salesColCount = ds.Tables["Online Sales"].Columns.Count;

                                                if (salesRowCount == 0)
                                                {
                                                    Console.WriteLine("No data found!");
                                                }
                                                else
                                                {
                                                    Console.WriteLine();
                                                    for (int j = 0; j < salesRowCount; j++)
                                                    {
                                                        for (int k = 0; k < salesColCount; k++)
                                                        {
                                                            Console.Write(ds.Tables["Online Sales"].Columns[k] + ": "
                                                                + ds.Tables["Online Sales"].Rows[j][k].ToString() + "\n");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                }

                                                break;

                                            case 2:
                                                SqlDataAdapter da6 = new SqlDataAdapter("select o.order_id as 'Order ID', o.order_method as 'Order Method', " +
                                                    "o.order_type as 'Order Type', o.item as 'Item Name', o.empID as 'Employee ID', " +
                                                    "o.amount as Amount, o.date as Date, e.franchise_id as 'Franchise ID' " +
                                                    "from orders o " +
                                                    "inner join employees e on o.empID = e.empID " +
                                                    "where e.franchise_id = '" + loginID + "' " +
                                                    "and o.order_method = 'Offline'", con);

                                                da6.Fill(ds, "Offline Sales");
                                                salesRowCount = ds.Tables["Offline Sales"].Rows.Count;
                                                salesColCount = ds.Tables["Offline Sales"].Columns.Count;

                                                if (salesRowCount == 0)
                                                {
                                                    Console.WriteLine("No data found!");
                                                }
                                                else
                                                {
                                                    Console.WriteLine();
                                                    for (int j = 0; j < salesRowCount; j++)
                                                    {
                                                        for (int k = 0; k < salesColCount; k++)
                                                        {
                                                            Console.Write(ds.Tables["Offline Sales"].Columns[k] + ": "
                                                                + ds.Tables["Offline Sales"].Rows[j][k].ToString() + "\n");
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                }

                                                break;

                                            default:
                                                Console.WriteLine("Incorrect Choice");

                                                break;
                                        }

                                        break;

                                    default:
                                        Console.WriteLine("Incorrect Choice");

                                        break;
                                }


                                Console.WriteLine("Do you want to start again? (Y/N)");
                                repeat = Console.ReadLine();
                            }
                            break;
                        }
                    }
                }
            }
            if (!loggedIn)
                Console.WriteLine("Incorrect credentials.");
        }
    }
}
