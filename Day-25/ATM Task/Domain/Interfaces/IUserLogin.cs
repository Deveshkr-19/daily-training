using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_Task.Domain.Interfaces
{
    public interface IUserLogin
    {
        void CheckUserCardNumAndPassword();
    }
}
