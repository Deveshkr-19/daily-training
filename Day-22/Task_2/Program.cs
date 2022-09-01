using System;
using System.Data;
using System.Data.SqlClient;

namespace Task_2
{
    class Program
    {
        enum Categories
        {
            Cosmetics = 1,
            Footwear,
            Garments
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter you ID and password.");
            int loginID = int.Parse(Console.ReadLine());
            string pass = Console.ReadLine();


            // Connection strings
            SqlConnection con = new SqlConnection("server=localhost;database=fashion_store;integrated security=true");
            SqlDataAdapter da = new SqlDataAdapter("select * from login", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Admin");
            int loginCount = ds.Tables[0].Rows.Count;
            //ds.Tables[0].Rows.;

            for (int i = 0; i < loginCount; i++)
            {
                if (loginID.ToString() == ds.Tables[0].Rows[i][0].ToString())
                {
                    if (pass.ToString() == ds.Tables[0].Rows[i][1].ToString())
                    {
                        Console.WriteLine("Successfully logged in!\n");

                        string repeat = "Y";
                        while (repeat.ToUpper() == "Y")
                        {
                            Console.WriteLine(@"Enter 1 for insertion
Enter 2 for deletion
Enter 3 for updation
Enter 4 for searching
Enter 5 to search for products whose quantity is greater than a 20:");
                            int choice = int.Parse(Console.ReadLine());

                            Products prod = new Products();

                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("Enter the name of the product you want to insert:");
                                    prod.p_name = Console.ReadLine();
                                    Console.WriteLine("Enter the price for the product:");
                                    prod.p_price = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the quantity for the product:");
                                    prod.p_qty = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the category ID as 1 for Cosmetics, 2 for Footwear and 3 for Garments");
                                    prod.c_id = int.Parse(Console.ReadLine());

                                    // Command creation
                                    SqlCommand insCmd = new SqlCommand("insert into products values('" + prod.p_name + "', " + prod.p_price + ", " + prod.p_qty + " , " + prod.c_id + ")", con);

                                    con.Open();
                                    insCmd.ExecuteNonQuery();
                                    con.Close();
                                    Console.WriteLine("Record inserted successfully!");

                                    break;

                                case 2:
                                    Console.WriteLine("Enter the ID of the product you want to delete:");
                                    prod.p_id = int.Parse(Console.ReadLine());

                                    // Command creation
                                    SqlCommand delCmd = new SqlCommand("delete from products where p_id = " + prod.p_id + " ", con);

                                    con.Open();
                                    delCmd.ExecuteNonQuery();
                                    con.Close();
                                    Console.WriteLine("Record deleted successfully!");

                                    break;

                                case 3:
                                    Console.WriteLine("Enter the ID of the product you want to update:");
                                    prod.p_id = int.Parse(Console.ReadLine());

                                    Console.WriteLine("Enter the name of the product you want to update:");
                                    prod.p_name = Console.ReadLine();
                                    Console.WriteLine("Enter the price for the product:");
                                    prod.p_price = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the quantity for the product:");
                                    prod.p_qty = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter the category ID as 1 for Cosmetics, 2 for Footwear and 3 for Garments");
                                    prod.c_id = int.Parse(Console.ReadLine());

                                    // Command creation
                                    SqlCommand updCmd = new SqlCommand("update products set p_name = '" + prod.p_name + "', p_price = " + prod.p_price + ", p_qty = " + prod.p_qty + ", c_id = " + prod.c_id + " where p_id = " + prod.p_id, con);

                                    con.Open();
                                    updCmd.ExecuteNonQuery();
                                    con.Close();
                                    Console.WriteLine("Record updated successfully!");

                                    break;

                                case 4:
                                    Console.WriteLine("Enter id of the product to be searched");
                                    prod.p_id = int.Parse(Console.ReadLine());

                                    SqlDataAdapter da2 = new SqlDataAdapter("select * from products", con);
                                    da2.Fill(ds, "Products");
                                    int x = ds.Tables[1].Rows.Count;
                                    Console.WriteLine(x);


                                    for (int j = 0; j < x; j++)
                                    {
                                        if (prod.p_id.ToString() == ds.Tables["Products"].Rows[j][0].ToString())
                                        {
                                            Console.WriteLine("Product Name: " + ds.Tables["Products"].Rows[j][1].ToString());
                                            Console.WriteLine("Product Price: " + ds.Tables["Products"].Rows[j][2].ToString());
                                            Console.WriteLine("Product Quantity: " + ds.Tables["Products"].Rows[j][3].ToString());
                                            Console.WriteLine("Category: " + Enum.GetName(typeof(Categories), ds.Tables["Products"].Rows[j][4]));
                                        }
                                    }
                                    break;

                                case 5:
                                    SqlDataAdapter da3 = new SqlDataAdapter("select * from products", con);
                                    da3.Fill(ds, "Products");
                                    int y = ds.Tables["Products"].Rows.Count;

                                    Predicate<int> quanObj = new Predicate<int>(prod.checkQty);
                                    for (int j = 0; j < y; j++)
                                    {
                                        if (quanObj.Invoke(int.Parse(ds.Tables["Products"].Rows[j][3].ToString())))
                                        {
                                            Console.WriteLine("Product Name: " + ds.Tables["Products"].Rows[j][1].ToString());
                                            Console.WriteLine("Product Price: " + ds.Tables["Products"].Rows[j][2].ToString());
                                            Console.WriteLine("Product Quantity: " + ds.Tables["Products"].Rows[j][3].ToString());
                                            Console.WriteLine("Category: " + Enum.GetName(typeof(Categories), ds.Tables["Products"].Rows[j][4]));
                                            Console.WriteLine();
                                        }
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
