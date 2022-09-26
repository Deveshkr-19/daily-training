using System;
using System.Collections.Generic;
using System.Text;

namespace Polling.Interfaces
{
    public interface IUser
    {
        void userRegister();
        void castVote(int user_id);
    }
}
