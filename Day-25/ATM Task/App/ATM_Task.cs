using ATM_Task.Domain.Entities;
using ATM_Task.Domain.Interfaces;
using ATM_Task.UI;
using System;
using System.Collections.Generic;

namespace ATM_Task
{
    public class ATM_Task : IUserLogin
    {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;

        public void InitializeData()
        {
            userAccountList = new List<UserAccount>
            {
                new UserAccount{Id = 1, FullName = "Devesh Kumar Singh", AccountNumber=123456, CardNumber=321321, CardPin=123123, AccountBalance=5000.00m,IsLocked=false},
                new UserAccount{Id = 2, FullName = "Anjali Saini", AccountNumber=456789, CardNumber=654654, CardPin=456456, AccountBalance=4000.00m,IsLocked=false},
                new UserAccount{Id = 3, FullName = "Naina Upadhyay", AccountNumber=123555, CardNumber=987987, CardPin=789789, AccountBalance=7000.00m,IsLocked=true},
            };
        }

        public void CheckUserCardNumAndPassword()
        {
            bool isCorrectLogin = false;

            UserAccount tempUserAccount = new UserAccount();

            tempUserAccount.CardNumber = Validator.Convert<long>("Your card number:");
            tempUserAccount.CardPin = 
        }
    }
}
