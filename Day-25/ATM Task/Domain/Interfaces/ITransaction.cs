using ATM_Task.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Task.Domain.Interfaces
{
    public interface ITransaction
    {
        void InsertTransaction(long _UserBankAccountId, TransactionType _tranType, decimal _tranAmount, string _desc);
        void ViewTransaction();
    }
}
