using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MeramecNetFlixProject.Business_Objects;
using Dapper;

namespace MeramecNetFlixProject.Data_Access_Layer
{
    public static class WatchListDB
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
        // use this for now until you get some data in the rentals table then use this query on rentals table
        public static List<Movie> GetTopThree()
        {
            List<WatchList> top3 = new List<WatchList>();
            Movie wmovie = new Movie();
            List<Movie> topMovies = new List<Movie>();
            string connectionString = GetConnectionString();
            // gets the count of each group of movie titles then returns the top three counts
            string sqlStatement = "SELECT TOP(3) Movie_number, COUNT(*) as num_of_rentals " +
                " FROM WatchList GROUP BY Movie_number ORDER BY num_of_rentals DESC ";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    top3 = db.Query<WatchList>(sqlStatement).ToList();
                }
                for (int numMovies = 0; numMovies <= top3.Count; numMovies++)
                {
                    wmovie = MovieDB.GetMovieFromWatchList(top3[numMovies]);
                    topMovies.Add(wmovie);
                }
            }
            catch(Exception ex)
            { throw ex; }
       
            return topMovies;
        }

        public static List<WatchList> GetWatchLists()
        {
            List<WatchList> watchlist = new List<WatchList>();
            string conectionString = GetConnectionString();
            string sqlStatement = "SELECT * FROM WatchList ORDER BY member_id";

            try
            {
                using (IDbConnection db = new SqlConnection(conectionString))
                {
                    watchlist = db.Query<WatchList>(sqlStatement).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return watchlist;
        }
        // gets the number of people watching a certain movie
        public static List<WatchList> GetWatchListMembers(WatchList movieId)
        {
            string connectionString = GetConnectionString();
            List<WatchList> listOfMembers = new List<WatchList>();
            string sqlStatement2 = "SELECT member_id FROM WatchList " +
                " WHERE movie_number = @movie_number";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@movie_number", movieId.Movie_Number, DbType.Int32, ParameterDirection.Input);

                    listOfMembers = db.Query<WatchList>(sqlStatement2, parm).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listOfMembers;
        }
        public static List<Movie> GetWatchList(Member mId)
        {
            Movie wmovie = new Movie();
            List<Movie> watchList = new List<Movie>();
            string connectionString = GetConnectionString();
            List<WatchList> listOfMovies = new List<WatchList>();
            string sqlStatement2 = "SELECT * FROM WatchList " +
                " WHERE member_id = @member_id";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@movie_number", mId.Member_Number, DbType.Int32, ParameterDirection.Input);

                    listOfMovies = db.Query<WatchList>(sqlStatement2, parm).ToList();
                }
                for (int movie = 0; movie <= listOfMovies.Count; movie++)
                {
                    wmovie = MovieDB.GetMovieFromWatchList(listOfMovies[movie]);
                    watchList.Add(wmovie);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return watchList;
        }
       
        public static bool SpAddWatchListMovie(int member, int movie, DateTime dateAdd)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string conStr = GetConnectionString();
            var procedure = "[AddWatchListMovie]";
            var values = new { memberNum = member, movieNum = movie, date = dateAdd };

            try
            {
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    rowsAffected = db.Execute(procedure, values, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            returnStatus = rowsAffected > 0 ? true : false;
            return returnStatus;
        }
        public static List<WatchList> SpGetMemberWatchList(int id)
        {
            string conStr = GetConnectionString();
            var procedure = "[GetMemberWatchList]";
            var values = new { member=id};
            List<WatchList> wlist = new List<WatchList>();

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    wlist = db.Query<WatchList>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return wlist;
        }
        public static bool addList(WatchList wList)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string SqlStatement = "INSERT INTO WatchList " +
                "VALUES(@member_id,@movie_number,@date_add)";


            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@member_id", wList.Member_Id, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@movie_number", wList.Movie_Number, DbType.String, ParameterDirection.Input);
                    parameters.Add("@date_add", wList.Movie_Number, DbType.DateTime, ParameterDirection.Input);

                    rowsAffected = db.Execute(SqlStatement, parameters);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            returnStatus = rowsAffected > 0 ? true : false;

            return returnStatus;
        }
        public static bool addList(int memberId, int movieId, DateTime dateAdd)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string SqlStatement = "INSERT INTO WatchList " +
                "VALUES(@member_id,@movie_number,@date_add)";


            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@member_id", memberId, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@movie_number", movieId, DbType.String, ParameterDirection.Input);
                    parameters.Add("@date_add", dateAdd, DbType.DateTime, ParameterDirection.Input);

                    rowsAffected = db.Execute(SqlStatement, parameters);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            returnStatus = rowsAffected > 0 ? true : false;

            return returnStatus;
        }
        public static bool UpdateMovie(WatchList wList)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string SQLStatement = "UPDATE WatchList " +
                " SET movie_number = @movie_number " +
                "  WHERE member_id = @member_id";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@member_id", wList.Member_Id, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@movie_number", wList.Movie_Number, DbType.String, ParameterDirection.Input);

                    rowsAffected = db.Execute(SQLStatement, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            returnStatus = rowsAffected > 0 ? true : false;
            return returnStatus;
        }
        public static bool SpDeleteMovie(int memberId, int movieId)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string conStr = GetConnectionString();
            string procedure = "[DeleteMovieWL]";
            var values = new { memberNum = memberId, movieNum = movieId };

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    rowsAffected = db.Execute(procedure, values, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            returnStatus = rowsAffected > 0 ? true : false;
            return returnStatus;
        }
        public static bool DeleteMovie(WatchList wList)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlStatement = "DELETE WatchList WHERE member_id = @member_id";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@member_id", wList.Member_Id, DbType.Int32, ParameterDirection.Input);

                    rowsAffected = db.Execute(sqlStatement, parameters);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            returnStatus = rowsAffected > 0 ? true : false;
            return returnStatus;
        }
    }
}
