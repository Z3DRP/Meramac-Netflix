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
    public static class RatingDB
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
        public static List<MovieRating> SpGetAllRatings()
        {
            string connectionString = GetConnectionString();
            var procedure = "[GetAllRatings]";
            List<MovieRating> rList = new List<MovieRating>();

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    rList = db.Query<MovieRating>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return rList;
        }
        public static MovieRating SpGetRatingId(string ratingName)
        {
            string conString = GetConnectionString();
            var procedure = "[GetRatingId]";
            var value = new { name = ratingName };
            MovieRating id = new MovieRating();

            try
            {
                using (IDbConnection db = new SqlConnection(conString))
                {
                    id = db.QuerySingle(procedure, value, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return id;
        }
        public static MovieRating SpGetRating(int ratingId)
        {
            string conStr = GetConnectionString();
            var procedure = "[GetRating]";
            var value = new { id = ratingId };
            MovieRating rating = new MovieRating();

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    rating = db.QuerySingle<MovieRating>(procedure, value, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return rating;

        }
        public static List<MovieRating> GetRatings()
        {

            //Change the MyCustomObject name to your customer business object that is returning data from the specific table
            List<MovieRating> rList = new List<MovieRating>();
            string connectionString = GetConnectionString();
            string SQLStatement = "SELECT id, rating FROM Rating ORDER BY id";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    rList = db.Query<MovieRating>(SQLStatement).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return rList;
        }
    }
}
