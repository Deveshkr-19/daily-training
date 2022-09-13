using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace AutoMobile
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connection strings
            SqlConnection con = new SqlConnection("server=localhost;database=cars_db;integrated security=true");
            DataSet ds = new DataSet();

            string salRecord = @"C:\training\daily-training\Assessments\Assessment 12-Sep\AutoMobile\SalaryRecords.txt";

            QueryExecute q = new QueryExecute();
            Action<SqlConnection, SqlCommand> sqlCmd = q.CmdExecute;

            CheckParts check = new CheckParts();


            string repeat = "Y";
            while (repeat.ToUpper() == "Y")
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to calculate and distribute salaries\n" +
                    "Enter 2 to view calculated salaries\n" +
                    "Enter 3 to calculate the manufacturing price and the purchase cost of the car\n" +
                    "Enter 4 to calculate repairing cost\n");
                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        if (File.Exists(salRecord))
                            File.Delete(salRecord);

                        if (ds.Tables.CanRemove(ds.Tables["Hrs_worked Hrly_salary"]))
                            ds.Tables.Remove(ds.Tables["Hrs_worked Hrly_salary"]);

                        int working_hrs = 184;

                        SqlDataAdapter sal_da = new SqlDataAdapter("select e.emp_id, e.name, " +
                            "d.dept_head, m.hours_worked, d.hrly_salary from Employee e " +
                            "Inner Join Monthly_hours m on e.emp_id = m.emp_id inner join " +
                            "Department d on e.dept_id = d.dept_id", con);

                        sal_da.Fill(ds, "Hrs_worked Hrly_salary");

                        int hrsRowCount = ds.Tables["Hrs_worked Hrly_salary"].Rows.Count;

                        for(int i = 0; i < hrsRowCount; i++)
                        {
                            double hrly_salary, total_salary;
                            if(ds.Tables["Hrs_worked Hrly_salary"].Rows[i][0] == ds.Tables["Hrs_worked Hrly_salary"].Rows[i][2])
                            {
                                hrly_salary = (double)ds.Tables["Hrs_worked Hrly_salary"].Rows[i][4] + 50;
                            }
                            else
                            {
                                hrly_salary = (double)ds.Tables["Hrs_worked Hrly_salary"].Rows[i][4];
                            }
                            int hrs_worked = (int)ds.Tables["Hrs_worked Hrly_salary"].Rows[i][3];

                            total_salary = hrs_worked > working_hrs ?
                                ((working_hrs * hrly_salary) + ((hrs_worked - working_hrs) * hrly_salary * 2)) : 
                                (working_hrs * hrly_salary);

                            if (!File.Exists(salRecord))
                                using (StreamWriter sw = File.CreateText(salRecord))
                                {
                                    sw.WriteLine($"Emp. ID: {ds.Tables["Hrs_worked Hrly_salary"].Rows[i][0]}\t/\t" +
                                        $"Name: {ds.Tables["Hrs_worked Hrly_salary"].Rows[i][1]}\t/\t" +
                                        $"Salary: {total_salary}");
                                }
                            else
                                using (StreamWriter sw = File.AppendText(salRecord))
                                {
                                    sw.WriteLine($"Emp. ID: {ds.Tables["Hrs_worked Hrly_salary"].Rows[i][0]}\t/\t" +
                                        $"Name: {ds.Tables["Hrs_worked Hrly_salary"].Rows[i][1]}\t/\t" +
                                        $"Salary: {total_salary}");
                                }
                        }

                        Console.WriteLine("\nSalaries have been calculated and distributed.");


                        break;

                    case 2:
                        if (!File.Exists(salRecord))
                            Console.WriteLine("No records found. Please calculate salaries first.");

                        else
                        {
                            Console.WriteLine("\nHere are the calculated records:\n");

                            using (StreamReader sr = File.OpenText(salRecord))
                            {
                                string s = "";
                                while ((s = sr.ReadLine()) != null)
                                {
                                    Console.WriteLine(s);
                                }
                            }
                            Console.WriteLine();
                        }
                        
                        
                        break;

                    case 3:
                        if (ds.Tables.CanRemove(ds.Tables["All Parts Details"]))
                            ds.Tables.Remove(ds.Tables["All Parts Details"]);

                        SqlDataAdapter allParts_da = new SqlDataAdapter("select * from products", con);
                        allParts_da.Fill(ds, "All Parts Details");
                        int allPartsRowCount = ds.Tables["All Parts Details"].Rows.Count;

                        double manufacture_cost = 0;

                        for (int i = 0; i < allPartsRowCount; i++)
                        {
                            if (check.CheckMultParts(ds.Tables["All Parts Details"].Rows[i][1].ToString(), MultiParts.fourParts))
                            {
                                manufacture_cost += 4 * (double)ds.Tables["All Parts Details"].Rows[i][2];
                                SqlCommand fourPartsStock = new SqlCommand($"update Stocks set quantity = quantity - 4 " +
                                    $"where prod_id = {ds.Tables["All Parts Details"].Rows[i][0]}", con);

                                sqlCmd.Invoke(con, fourPartsStock);

                            }
                            else if (check.CheckMultParts(ds.Tables["All Parts Details"].Rows[i][1].ToString(), MultiParts.twoParts))
                            {
                                manufacture_cost += 2 * (double)ds.Tables["All Parts Details"].Rows[i][2];
                                SqlCommand twoPartsStock = new SqlCommand($"update Stocks set quantity = quantity - 2 " +
                                    $"where prod_id = {ds.Tables["All Parts Details"].Rows[i][0]}", con);

                                sqlCmd.Invoke(con, twoPartsStock);
                            }
                            else
                            {
                                manufacture_cost += (double)ds.Tables["All Parts Details"].Rows[i][2];
                                SqlCommand onePartStock = new SqlCommand($"update Stocks set quantity = quantity - 1 " +
                                    $"where prod_id = {ds.Tables["All Parts Details"].Rows[i][0]}", con);

                                sqlCmd.Invoke(con, onePartStock);
                            }
                            manufacture_cost += 1000;
                        }

                        Console.WriteLine($"\n\nThe manufacturing price inclusive of manpower cost is: {manufacture_cost}");

                        manufacture_cost += (35 * manufacture_cost) / 100;

                        Console.WriteLine($"\nThe cost price of the car with 35% profit is: {manufacture_cost}\n");

                        break;

                    case 4:
                        Console.WriteLine("Enter the number of parts to be replaced:");
                        int nParts = int.Parse(Console.ReadLine());


                        if (ds.Tables.CanRemove(ds.Tables["Parts Details"]))
                            ds.Tables.Remove(ds.Tables["Parts Details"]);

                        int[] partsArr = new int[nParts];
                        SqlDataAdapter parts_da = new SqlDataAdapter("select * from products", con);
                        parts_da.Fill(ds, "Parts Details");
                        int partsRowCount = ds.Tables["Parts Details"].Rows.Count;

                        double repair_cost = nParts * 800;

                        for (int i = 0; i < nParts; i++)
                        {
                            Console.WriteLine("\nPlease select the number corresponding to the part which is to be replaced");
                            for (int j = 0; j < partsRowCount; j++)
                            {
                                Console.WriteLine($"Select {ds.Tables["Parts Details"].Rows[j][0]} for " +
                                    $"{ds.Tables["Parts Details"].Rows[j][1]} replacement.");
                            }
                            partsArr[i] = int.Parse(Console.ReadLine());
                            Console.Clear();
                        }


                        for (int i = 0; i < nParts; i++)
                            for (int j = 0; j < partsRowCount; j++)
                                if((int)ds.Tables["Parts Details"].Rows[j][0] == partsArr[i])
                                {
                                    repair_cost += (double)ds.Tables["Parts Details"].Rows[j][2];
                                    SqlCommand repStock = new SqlCommand($"update Stocks set quantity = quantity - 1 " +
                                        $"where prod_id = {partsArr[i]}", con);

                                    sqlCmd.Invoke(con, repStock);

                                    break;
                                }
                        
                        Console.WriteLine($"Total cost for the repairing: {repair_cost}.\n");

                        break;

                    default:
                        Console.WriteLine("Wrong choice of input provided.");

                        break;
                }



                Console.WriteLine("Do you want to start again? (Y/N)");
                repeat = Console.ReadLine();
            }

            if (File.Exists(salRecord))
                File.Delete(salRecord);
        }
    }
}
