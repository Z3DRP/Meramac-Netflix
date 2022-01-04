using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//The System.Data.SqlClient reference is needed to access SQL Server database
using System.Data.SqlClient;
using System.Configuration;

namespace MeramecNetFlixProject
{
    public static class AccessDataSQLServer
    {
        // new connection string is located in app.config file

        //public static string GetConnectionString =>
        //    "Server=mc-sluggo.stlcc.edu; Database= IS253_Palmer; User id= palmer;Password= palmer; ";

        public static string GetConnectionString()
        {
            string connectString = null;
            try
            {
                connectString = ConfigurationManager.ConnectionStrings["MeramacConnectString"].ConnectionString;
            }
            catch(Exception ex)
            { throw ex; }

            if (connectString != null)
                return connectString;
            else
                return string.Empty;
        }
    }

   
}
