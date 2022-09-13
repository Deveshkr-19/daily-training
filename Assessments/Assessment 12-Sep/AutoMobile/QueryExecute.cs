using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AutoMobile
{
    public class QueryExecute : IQueryExecute
    {
        public void CmdExecute(SqlConnection con, SqlCommand cmd)
        {
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
