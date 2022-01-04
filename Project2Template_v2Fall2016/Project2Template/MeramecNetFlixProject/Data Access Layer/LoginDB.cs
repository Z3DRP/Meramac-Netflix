using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeramecNetFlixProject.Business_Objects;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace MeramecNetFlixProject.Data_Access_Layer
{
    public static class LoginDB
    {

        private static string GetConnectionString()
        {
            //string connectionString = "Server=mc-sluggo.stlcc.edu; Database= IS253_Palmer; User id= palmer;Password= palmer; ";
            string connectionString = null;
            try
            {
                connectionString = AccessDataSQLServer.GetConnectionString();
            }
            catch (Exception ex)
            { throw ex; }

            if (connectionString != null)
                return connectionString;
            else
                return string.Empty;
        }
        // returns if the login credintials are valid
        public static  Login GetLogin(Login login)
        {
            string connectString = GetConnectionString();
            var procedure = "[GetLoginInfo]";
            var value = new { user= login.UserName };
            Login loginInfo = new Login();

            try
            {
                using (IDbConnection db = new SqlConnection(connectString))
                {
                    loginInfo = db.QuerySingle<Login>(procedure, value, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return loginInfo;
        }
        public static Member SpGetMember(Login loginInfo)
        {
            string connectString = GetConnectionString();
            var procedure = "[MemberInfoByUser]";
            var value = new { user= loginInfo.UserName };
            Member selectedMember = new Member();

            try
            {
                using (IDbConnection db = new SqlConnection(connectString))
                {
                    selectedMember = db.QuerySingle<Member>(procedure, value, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return selectedMember;
        }
    }
}
