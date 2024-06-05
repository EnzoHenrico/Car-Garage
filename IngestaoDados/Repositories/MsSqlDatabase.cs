using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MsSqlDatabase
    {
        public SqlConnection Connection = new()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString
        };
    }
}
