using Polling.Interfaces;
using Polling.PollingApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Polling.Models
{
    public class Admin : IAdmin, IDelVoter 
    {
        public string id { get; set; }
        public string password { get; set; }

        static VotingApp obj = new VotingApp();

        public void checkLogin()
        {
            Console.WriteLine("Enter you ID and password for logging in:");
            id = Console.ReadLine();
            password = Console.ReadLine();
            SqlDataAdapter login_da = new SqlDataAdapter("select * from Login", obj.con);
            DataSet ds = new DataSet();
            login_da.Fill(ds, "Login");
            int loginCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < loginCount; i++)
            {
                if (id.ToString() == ds.Tables[0].Rows[i][0].ToString())
                {
                    if (password.ToString() == ds.Tables[0].Rows[i][1].ToString())
                    {
                        Console.WriteLine("Successfully logged in!\n");
                    }
                }
            }
        }

        public static int checkLoginUser()
        {
            Console.WriteLine("Enter you ID and dob in the format (DD/MM/YYYY) for logging in:");
            int id = int.Parse(Console.ReadLine());
            string dob = Console.ReadLine();
            SqlDataAdapter user_da = new SqlDataAdapter("select * from Voter_Detail " +
                "where voter_id = " + id + " and dob = '" + dob +"'", obj.con);
            DataSet ds = new DataSet();
            user_da.Fill(ds, "Voter_Detail");
            int loginCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < loginCount; i++)
            {
                if ((id.ToString() == ds.Tables[0].Rows[i][0].ToString()) && (dob.ToString() == ds.Tables[0].Rows[i][4].ToString()))
                {
                    Console.WriteLine("Successfully logged in!\n");
                    return id;
                }
            }
            return -1;
        }

        public void delVoter()
        {
            try
            {
                User_Details user = new User_Details();
                Console.WriteLine("Enter id of the voter to delete. ");
                user.voter_id = int.Parse(Console.ReadLine());
                Console.WriteLine("Data inserted sucessfully");
                string query1 = "delete from Voter_Detail where voter_id=" + user.voter_id + "";

                SqlCommand cmd1 = new SqlCommand(query1, obj.con);
                obj.con.Open();
                cmd1.ExecuteNonQuery();
                obj.con.Close();
                Console.WriteLine("voter deleted sucessfully");

            }
            catch (Exception)
            {
                Console.WriteLine("give correct id");
            }
        }

        public void registerParty()
        {
            try
            {
                Party_Details party = new Party_Details();

                Console.WriteLine("Enter your party's name ");
                party.Name = Console.ReadLine();
                Console.WriteLine("Enter your party's symbol ");
                party.Symbol = Console.ReadLine();
                Console.WriteLine("Enter your party's leader ");
                party.Leader = Console.ReadLine();
                Console.WriteLine("Data inserted sucessfully");


                SqlCommand cmd = new SqlCommand("insert into Party_Details values('"
                    + party.Name + "','" + party.Symbol + "','" + party.Leader + "', 0)", obj.con);
                obj.con.Open();
                cmd.ExecuteNonQuery();
                obj.con.Close();
                Console.WriteLine("Party registered sucessfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void TotalVotes()
        {
            try
            {
                Console.WriteLine("Data inserted sucessfully");
                SqlDataAdapter dad = new SqlDataAdapter("select * from Party_Details", obj.con);
                SqlDataAdapter votes_da = new SqlDataAdapter("select sum(votes) as 'Total Votes' from Party_Details", obj.con);
                DataSet ds = new DataSet();
                dad.Fill(ds, "partyVotes");
                votes_da.Fill(ds, "totalVotes");
                int data = ds.Tables[0].Rows.Count;
                for (int i = 0; i < data; i++)
                {
                    Console.Write("id : " + ds.Tables[0].Rows[i][0].ToString());
                    Console.Write("\tName : " + ds.Tables[0].Rows[i][1].ToString());
                    Console.Write("\tSymbol : " + ds.Tables[0].Rows[i][2].ToString());
                    Console.Write("\tTotal Votes : " + ds.Tables[0].Rows[i][4].ToString());
                    Console.WriteLine();
                }
                Console.WriteLine($"\n{ds.Tables["totalVotes"].Columns[0].ColumnName}: {ds.Tables["totalVotes"].Rows[0][0]}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
