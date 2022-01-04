using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using MeramecNetFlixProject.Business_Objects;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Windows.Forms;
using MeramecNetFlixProject.Business_Objects;
using MeramecNetFlixProject.Data_Access_Layer;

namespace MeramecNetFlixProject.Data_Access_Layer
{
    public static class MemberDB
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
        public static List<Member> GetMembers()
        {
            List<Member> memberList = new List<Member>();
            string connectionString = GetConnectionString();
            string sqlStatement = "SELECT * FROM members ORDER BY member_number";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    memberList = db.Query<Member>(sqlStatement).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return memberList;
        }
        public static List<Member> SpGetMemberById(int mId)
        {
            // only returning a list because the listview will not show anything  but a list
            string conStr = GetConnectionString();
            var procedure = "[GetMemberById]";
            var value = new { mId = mId };
            List<Member> members = new List<Member>();
            try
            {
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    members = db.Query<Member>(procedure, value, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return members;
        }
        public static List<Member> SpGetMembersByLastname(string lastname)
        {
            string conStr = GetConnectionString();
            var procedure = "[GetMemberByLastname]";
            string lnameWC = lastname + "%";
            var value = new { lname = lnameWC };
            List<Member> members = new List<Member>();

            try
            {
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    members = db.Query<Member>(procedure, value, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return members;
        }
        public static bool AddMember(Member member)
        {
            int rowsAffected;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlStatement = "INSERT INTO members " +
                " VALUES(@member_status,@member_number,@join_date,@first_name,@last_name,@zipcode,@cell_phone,@username,@password,@email)";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters Params = new DynamicParameters();
                    Params.Add("@member_status", member.Member_Status, DbType.String, ParameterDirection.Input);
                    Params.Add("@member_number", member.Member_Number, DbType.Int32, ParameterDirection.Input);
                    Params.Add("@join_date", member.Join_Date, DbType.DateTime, ParameterDirection.Input);
                    Params.Add("@first_name", member.First_Name, DbType.String, ParameterDirection.Input);
                    Params.Add("@last_name", member.Last_Name, DbType.String, ParameterDirection.Input);
                    Params.Add("@zipcode", member.Zipcode, DbType.String, ParameterDirection.Input);
                    Params.Add("@cell_phone", member.Cell_Phone, DbType.String, ParameterDirection.Input);
                    Params.Add("@username", member.Username, DbType.String, ParameterDirection.Input);
                    // when you add the encryption stuff you will need to add the encrypted password instead
                    Params.Add("@password", member.Password, DbType.String, ParameterDirection.Input);
                    Params.Add("@email", member.Email, DbType.String, ParameterDirection.Input);

                    rowsAffected = db.Execute(sqlStatement, Params);
                }
            }
            catch(Exception ex)
            { throw ex; }

            returnStatus = rowsAffected > 0 ? true : false;
            return returnStatus;     
        }
        public static bool UpdateMember(Member member)
        {
            int rowsAffected;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlStatement = "UPDATE members " +
                "  SET member_status = @member_status, " +
                "   join_date = @join_date, " +
                "   first_name = @first_name, " +
                "   last_name = @last_name, " +
                "   zipcode = @zipcode, " +
                "   cell_phone = @cell_phone, " +
                "   username = @username," +
                "   password = @password, " +
                "   email = @email " +
                " WHERE member_number = @member_number ";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters Params = new DynamicParameters();
                    Params.Add("@member_status", member.Member_Status, DbType.String, ParameterDirection.Input);
                    Params.Add("@member_number", member.Member_Number, DbType.Int32, ParameterDirection.Input);
                    Params.Add("@join_date", member.Join_Date, DbType.DateTime, ParameterDirection.Input);
                    Params.Add("@first_name", member.First_Name, DbType.String, ParameterDirection.Input);
                    Params.Add("@last_name", member.Last_Name, DbType.String, ParameterDirection.Input);
                    Params.Add("@zipcode", member.Zipcode, DbType.String, ParameterDirection.Input);
                    Params.Add("@cell_phone", member.Cell_Phone, DbType.String, ParameterDirection.Input);
                    Params.Add("@username", member.Username, DbType.String, ParameterDirection.Input);
                    // when you add the encryption stuff you will need to add the encrypted password instead
                    Params.Add("@password", member.Password, DbType.String, ParameterDirection.Input);
                    Params.Add("@email", member.Email, DbType.String, ParameterDirection.Input);

                    rowsAffected = db.Execute(sqlStatement, Params);
                }
            }
            catch(Exception ex)
            { throw ex; }

            returnStatus = rowsAffected > 0 ? true : false;
            return returnStatus;
        }
        public static int GetNextMemberNumber()
        {
            string connectString = GetConnectionString();
            var procedure = "[GetAllMembers]";
            List<Member> memberNumbers = new List<Member>();
            int NextMemberNumber;
            try
            {
                using (IDbConnection db = new SqlConnection(connectString))
                {
                    memberNumbers = db.Query<Member>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
                
                NextMemberNumber = memberNumbers.Count + 1;
            }
            catch (Exception ex)
            { throw ex; }

            return NextMemberNumber;
        }
        public static bool DeleteMember(Member member)
        {
            int rowsAffected;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlStatement = "DELETE members WHERE member_number = @member_number";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@member_number", member.Member_Number, DbType.Int32, ParameterDirection.Input);

                    rowsAffected = db.Execute(sqlStatement, param);
                }
            }
            catch(Exception ex)
            { throw ex; }

            returnStatus = rowsAffected > 0 ? true : false;
            return returnStatus;
        }
        
    }

}
