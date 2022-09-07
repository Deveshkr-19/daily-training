using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Task.Domain.Interfaces
{
    public interface IUserAccountActions
    {
        void CheckBalance();
        void PlaceDeposit();
        void MakeWithdrawal();
    }
}
