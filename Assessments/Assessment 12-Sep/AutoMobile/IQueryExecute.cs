using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace AutoMobile
{
    interface IQueryExecute
    {
        void CmdExecute(SqlConnection con, SqlCommand cmd);
    }
}
