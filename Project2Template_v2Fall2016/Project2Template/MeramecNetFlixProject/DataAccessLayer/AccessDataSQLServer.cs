using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//The System.Data.SqlClient reference is needed to access SQL Server database
using System.Data.SqlClient;

namespace MeramecNetFlixProject.DataAccessLayer
{
    public static class AccessDataSQLServer
    {
        
        public static SqlConnection GetConnection()
        {
            string connectionString = "Server=xxx.xxx.xxx.xxx;Database=Your database name;UserID=xxxx;Password=xxxx;";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }        

    }
       
}
