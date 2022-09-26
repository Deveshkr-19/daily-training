using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Polling.Interfaces;
using Polling.Models;
using Polling.Enums;
using System.Data;
using Polling.UI;

namespace Polling.PollingApp
{
    public class VotingApp : IUser
    {
        User_Details user = new User_Details();
        //Admin ad=new Admin();

        public SqlConnection con = new SqlConnection("server=localhost;database=polling_db;integrated security=true");

        public static void StartApp()
        {
            DisplayMenu.DisplayAppMenu();
            VotingApp.ProcessMenuoption();
        }

        public void userRegister()
        {
            try
            {

                Console.WriteLine("Enter your name ");
                user.Name = Console.ReadLine();
                Console.WriteLine("Enter Your Gender ");
                user.Gender = Console.ReadLine();
                Console.WriteLine("Enter the Email  ");
                user.Email = Console.ReadLine();
                Console.WriteLine("Enter your DOB.");
                user.Dob = Console.ReadLine();
                Console.WriteLine("Enter your Location ");
                user.Location= Console.ReadLine();
                Console.WriteLine("Your document for Verification ");
                user.Verification_doc = Console.ReadLine();


                SqlCommand cmd = new SqlCommand("insert into Voter_Detail values('" 
                    + user.Name + "','" + user.Gender + "','" + user.Email + "','" +
                    user.Dob + "','" + user.Location + "','" + user.Verification_doc 
                    + "', 0)", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayMenu.PrintDotAnimation();
                Console.WriteLine("Data inserted sucessfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void ProcessMenuoption()
        {
            int n = int.Parse(Console.ReadLine());
            DisplayMenu.PrintDotAnimation();
            VotingApp voteObj = new VotingApp();
            switch (n)
            {
                case (int)FirstMenu.AdminLogin:
                    Admin ad = new Admin();
                    ad.checkLogin();
                    string repeat = "Y";
                    while (repeat.ToUpper() == "Y")
                    {
                        DisplayMenu.DisplayAppMenuSecond();

                        int x = int.Parse(Console.ReadLine());
                        DisplayMenu.PrintDotAnimation();
                        switch (x)
                        {
                            case (int)AdminMenu.RegisterParties:
                                ad.registerParty();
                                break;
                            case (int)AdminMenu.DeleteVoters:
                                ad.delVoter();
                                break;
                            case (int)AdminMenu.TotalVotes:
                                ad.TotalVotes();
                                break;
                            default:
                                Console.WriteLine("wrong choice");
                                break;
                        }

                        Console.WriteLine("Do you want to repeat? (Y/N)");
                        repeat = Console.ReadLine();
                        Console.Clear();
                    }
                    break;
                case (int)FirstMenu.VotersLogin:
                    int user_id = Admin.checkLoginUser();
                    voteObj.castVote(user_id);
                    break;
                case (int)FirstMenu.VoterRegistration:
                    voteObj.userRegister();
                    break;
                default:
                    Console.WriteLine("wrong choice");
                    break;
            }
        }

       


        public void castVote(int user_id)
        {
            try
            {

                SqlDataAdapter voters_da = new SqlDataAdapter("select hasVoted " +
                    "from Voter_Detail where voter_id = " + user_id, con);
                DataSet ds = new DataSet();
                voters_da.Fill(ds, "HasVoted");
                SqlDataAdapter parties_da = new SqlDataAdapter("select * " +
                    "from Party_Details", con);
                parties_da.Fill(ds, "Parties");
                int partiesRowCount = ds.Tables["Parties"].Rows.Count;
                if (!(bool)ds.Tables["HasVoted"].Rows[0][0])
                {
                    Console.WriteLine("Select the ID for which party you want to vote");
                    for(int i = 0; i < partiesRowCount; i++)
                    {
                        Console.WriteLine($"{ds.Tables["Parties"].Rows[i][0]} \t " +
                            $"name: {ds.Tables["Parties"].Rows[i][1]} \t " +
                            $"symbol: {ds.Tables["Parties"].Rows[i][2]}");
                    }

                    Console.WriteLine("Enter ID here:");
                    int party_id = int.Parse(Console.ReadLine());
                    SqlCommand voteCmd = new SqlCommand("update Party_Details " +
                        "set votes = votes + 1 where party_id = '" + party_id + "'", con);
                    SqlCommand userVoteCmd = new SqlCommand("update Voter_Detail " +
                        "set hasVoted = 1 where voter_id = " + user_id + "", con);
                    con.Open();
                    voteCmd.ExecuteNonQuery();
                    userVoteCmd.ExecuteNonQuery();
                    con.Close();
                    Console.WriteLine("Vote has been casted. Thank you.");
                }
                else
                {
                    Console.WriteLine("You have already casted your vote.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
