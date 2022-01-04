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
    public static class RentalDB
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
        public static List<Rental> GetRentals()
        {
            List<Rental> rentalList = new List<Rental>();
            string connectionString = GetConnectionString();
            string sqlStatement = "SELECT * FROM rentals ORDER BY member_number";

            try
            {
                using(IDbConnection db = new SqlConnection(connectionString))
                {
                    rentalList = db.Query<Rental>(sqlStatement).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return rentalList;
        }
        public static Rental GetRental(Rental rental)
        {
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlStatement = "SELECT * FROM rentals " +
                "  WHERE movie_number = @movie_number AND member_number = @member_number AND media_purchase_date = @media_purchase_date";
            Rental requestedRental = new Rental();

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@movie_number", rental.Movie_Number, DbType.Int32, ParameterDirection.Input);
                    parm.Add("@member_number", rental.Member_Number, DbType.Int32, ParameterDirection.Input);
                    parm.Add("@media_purchase_date", rental.Media_Purchase_Date, DbType.DateTime, ParameterDirection.Input);

                    requestedRental = db.QuerySingle(sqlStatement, parm);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedRental;
        }
        public static List<Rental> GetRentalByMemberId(Rental member)
        {
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlStatement = "SELECT * FROM rentals " +
                "  WHERE member_number = @member_number";
            List<Rental> requestedRental = new List<Rental>();

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@movie_number", member.Member_Number, DbType.Int32, ParameterDirection.Input);
                    requestedRental = db.Query<Rental>(sqlStatement, parm).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return requestedRental;
        }
        public static bool AddRental(Rental rental)
        {
            int rowsAffected;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlStatement = "INSERT INTO rentals " +
                " VALUES(@movie_number,@member_number,@media_purchase_date,@media_streaming_start_date,@media_return_date)";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters paramS = new DynamicParameters();
                    paramS.Add("@movie_number", rental.Movie_Number, DbType.Int32, ParameterDirection.Input);
                    paramS.Add("@member_number", rental.Member_Number, DbType.Int32, ParameterDirection.Input);
                    paramS.Add("@media_purchase_date", rental.Media_Purchase_Date, DbType.DateTime, ParameterDirection.Input);
                    paramS.Add("@media_streaming_start_date", rental.Media_Streaming_Start_Date, DbType.DateTime, ParameterDirection.Input);
                    paramS.Add("@media_return_date", rental.Media_Return_Date, DbType.DateTime, ParameterDirection.Input);

                    rowsAffected = db.Execute(sqlStatement, paramS);
                }
            }
            catch(Exception ex)
            { throw ex; }

            returnStatus = rowsAffected > 0 ? true : false;
            return returnStatus;
        }
        public static bool UpdateRental(Rental rental)
        {
            int rowsAffected;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlStatement = "UPDATE rentals " +
                "   SET media_purchase_date = @media_purchase_date, " +
                "    media_streaming_start_date = @media_streaming_start_date, " +
                "    media_return_date = @return_date " +
                "  WHERE movie_number = @movie_number AND member_number = @member_number";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parms = new DynamicParameters();
                    parms.Add("@media_purchase_date", rental.Media_Purchase_Date, DbType.DateTime, ParameterDirection.Input);
                    parms.Add("@media_streaming_start_date", rental.Media_Streaming_Start_Date, DbType.DateTime, ParameterDirection.Input);
                    parms.Add("@return_date", rental.Media_Return_Date, DbType.DateTime, ParameterDirection.Input);
                    parms.Add("@movie_number", rental.Movie_Number, DbType.Int32, ParameterDirection.Input);
                    parms.Add("@member_number", rental.Member_Number, DbType.Int32, ParameterDirection.Input);

                    rowsAffected = db.Execute(sqlStatement, parms);
                }
            }
            catch(Exception ex)
            { throw ex; }

            returnStatus = rowsAffected > 0 ? true : false;
            return returnStatus;
        }
        public static bool DeleteRental(Rental rental)
        {
            int rowsAffected;
            bool returnStatus;
            string ConnectionString = GetConnectionString();
            string sqlStatement = "DELETE rentals WHERE movie_number = @movie_number AND member_number = @member_number AND media_purchase_date = @media_purchase_date";

            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@movie_number", rental.Movie_Number, DbType.Int32, ParameterDirection.Input);
                    parm.Add("@member_number", rental.Member_Number, DbType.Int32, ParameterDirection.Input);
                    parm.Add("@media_purchase_date", rental.Media_Purchase_Date, DbType.DateTime, ParameterDirection.Input);

                    rowsAffected = db.Execute(sqlStatement, parm);
                }
            }
            catch(Exception ex)
            { throw ex; }

            returnStatus = rowsAffected > 0 ? true : false;
            return returnStatus;
        }
        public static  List<Rental> SpGetRenatls()
        {
            string conStr = GetConnectionString();
            var procedure = "[GetRentals]";
            List<Rental> rentals = new List<Rental>();

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    rentals = db.Query<Rental>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return rentals;
        }
        public static List<Rental> SpGetRentalByMovie(Rental rented)
        {
            string conStr = GetConnectionString();
            var procedure = "[GetRentalsByMovieNumber]";
            var value = new { movieNum = rented.Movie_Number };
            List<Rental> rentals = new List<Rental>();

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    rentals = db.Query<Rental>(procedure, value, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return rentals;
        }
        public static List<Rental> SpGetRentalByMember(Rental member)
        {
            string conStr = GetConnectionString();
            var procedure = "[GetRentalsByMember]";
            var value = new { memberNum = member.Member_Number };
            List<Rental> rentals = new List<Rental>();

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    rentals = db.Query<Rental>(procedure, value, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return rentals;
        }
    }
}
