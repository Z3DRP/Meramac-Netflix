using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//The System.Data.SqlClient reference is needed to access SQL Server database
using System.Data.SqlClient;
using System.Data;
using MeramecNetFlixProject.Business_Objects;
using Dapper;


namespace MeramecNetFlixProject.Data_Access_Layer
{
    public static class GenreDB 
    {

        private static string GetConnectionString()
        {
            //cononection string is stored in app.config AccessDataSqlServer class has access to con string
            string connectionString = null;
            try
            {
                connectionString = AccessDataSQLServer.GetConnectionString();
            }
            catch(Exception ex)
            { throw ex; }

            if (connectionString != null)
                return connectionString;
            else
                return string.Empty;
        }
        public static List<Genre> GetGenres()
        {
            List<Genre> GenreList = new List<Genre>();
            string connectionString = GetConnectionString();
            string SQLStatement = "SELECT id, name FROM genres ORDER BY id";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    GenreList = db.Query<Genre>(SQLStatement).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

                     
            return GenreList;
        }

        public static string SpGetGenreName(int genreId)
        {
            string conStr = GetConnectionString();
            string genreName = string.Empty;
            var procedure = "[GetGenreName]";
            var value = new { genreId = genreId };

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    genreName = db.QuerySingle<string>(procedure, value, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return genreName;
        }
        public static Genre GetGenreName(Genre Parameter)
        {
            string connectionString = GetConnectionString();
            string sqlStatement = "SELECT * FROM genres " +
                "  WHERE id = @id";
            Genre requestedGenre = new Genre();

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@id", Parameter.id, DbType.Int32, ParameterDirection.Input);

                    requestedGenre = db.QuerySingle(sqlStatement, parm);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return requestedGenre;

        }

        public static int GetId(string name)
        {
            string connectionString = GetConnectionString();
            var procedure = "[GetGenreId]";
            var value = new { genreName = name };
            int genreId;

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    genreId = db.QuerySingle<int>(procedure, value, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return genreId;
        }

        public static bool AddGenre(Genre objGenre)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string SQLStatement = "INSERT INTO genres VALUES(@genre_id, @genre_name)";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@genre_id", objGenre.id, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@genre_name", objGenre.name, DbType.String, ParameterDirection.Input);

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

        public static bool UpdateGenre(Genre objGenre)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string SQLStatement = "UPDATE genres " +
                " SET name = @genre_name " +
                " WHERE id = @genre_id";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@genre_id", objGenre.id, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@genre_name", objGenre.name, DbType.String, ParameterDirection.Input);

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

        public static bool DeleteGenre(Genre objGenre)
        {

            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string SQLStatement = "DELETE genres WHERE id = @genre_id";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@genre_id", objGenre.id, DbType.Int32, ParameterDirection.Input);

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
        public static List<Genre> SpGetAllGenres(Genre genre)
        {
            string connectString = GetConnectionString();
            var procedure = "[GetGenreId]";
            List<Genre> genreId = new List<Genre>();
            try
            {
                var values = new { genreName = genre.name };
                using (IDbConnection db = new SqlConnection(connectString))
                {
                    genreId = db.Query<Genre>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return genreId;                     
        }
        public static List<Genre> SpGetGenreInfo()
        {
            string conStr = GetConnectionString();
            var procedure = "[GetGenreInfo]";
            List<Genre> genres = new List<Genre>();

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    genres = db.Query<Genre>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return genres;
        }
        public static List<Genre> SpGetGenreByName(string genre)
        {
            string conStr = GetConnectionString();
            var procedure = "[GenreWildCard]";
            string lnameWC = genre + "%";
            var value = new { genreName = lnameWC };
            List<Genre> genres = new List<Genre>();

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    genres = db.Query<Genre>(procedure, value, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return genres;
        }
        public static List<Genre> SpGetGenreById(int id)
        {
            string constr = GetConnectionString();
            var procedure = "[GetGenreName]";
            var value = new { genreId = id };
            List<Genre> genres = new List<Genre>();

            try
            {
                using (IDbConnection db = new SqlConnection(constr))
                {
                    genres = db.Query<Genre>(procedure, value, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return genres;
        }
        public static int GetNextGenreNumber()
        {
            string connectString = GetConnectionString();
            var procedure = "[GetGenreInfo]";
            List<Genre> genreNumbers = new List<Genre>();
            int NextGenreNumber;
            try
            {
                using (IDbConnection db = new SqlConnection(connectString))
                {
                    genreNumbers = db.Query<Genre>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }

                NextGenreNumber = genreNumbers.Count + 1;
            }
            catch (Exception ex)
            { throw ex; }

            return NextGenreNumber;
        }

    }
}
