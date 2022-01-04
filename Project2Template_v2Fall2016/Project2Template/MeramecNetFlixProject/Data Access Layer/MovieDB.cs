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
    public static class MovieDB
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
        public static List<Movie> SpGetAllMovies()
        {
            string conStr = GetConnectionString();
            var procedure = "[GetAllMovies]";
            List<Movie> movies = new List<Movie>();

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    movies = db.Query<Movie>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return movies;
        }
        public static List<Movie> SpGetMoviesByNumber(int number)
        {
            string conStr = GetConnectionString();
            var procedure = "[GetMovieByNumber]";
            var value = new { movieNum = number };
            List<Movie> movies = new List<Movie>();

            try
            {
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    movies = db.Query<Movie>(procedure, value, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return movies;
        }
        public static Movie SpGetMovieByNumber(int number)
        {
            string conStr = GetConnectionString();
            var procedure = "[GetMovieByNumber]";
            var value = new { movieNum = number };
            Movie movieReq = new Movie();

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    movieReq = db.QuerySingle<Movie>(procedure, value, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return movieReq;
        }
        public static List<Movie> SpSearchMovies(string movie)
        {
            string conStr = GetConnectionString();
            string movieWC = movie += '%';
            var procedure = "[SearchMovies]";
            var value = new { title= movieWC };
            List<Movie> movies = new List<Movie>();

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    movies = db.Query<Movie>(procedure, value, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return movies;
        }
        public static List<Movie> SpGetMoviesInGenere(string movieType)
        {
            string ConnectString = GetConnectionString();
            var procedure = "[GetMoviesByGenreId]";
            int genreId = GenreDB.GetId(movieType);
            var value = new { id = genreId };
            List<Movie> movies = new List<Movie>();

            try
            {
                using (IDbConnection db = new SqlConnection(ConnectString))
                {
                    movies = db.Query<Movie>(procedure, value, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return movies;
        }
        public static List<Movie> GetMoviesByGenre(string movieType)
        {
            string connectionString = GetConnectionString();
            List<Movie> requestedMovie = new List<Movie>();
            // get the id based off movietype passed in
            int  genreId = GenreDB.GetId(movieType);

            string sqlStatement2 = "SELECT * FROM MOVIES " +
                " WHERE genre_id = @genre_id";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@genre_id", genreId, DbType.Int32, ParameterDirection.Input);

                    requestedMovie = db.Query<Movie>(sqlStatement2,parm).ToList();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return requestedMovie;
        }
        public static List<Movie> SpGetMoviesFromGenre(int genreId)
        {
            string conStr = GetConnectionString();
            var procedure = "[GetMoviesByGenreId]";
            var value = new { id = genreId };
            List<Movie> movies = new List<Movie>();

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    movies = db.Query<Movie>(procedure, value, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return movies;
        }
        public static bool AddMovie(Movie movie)
        {
            // movie_number, movie_title, description, movie_year_made, genre_id, movie_rating, image, rental_duration, trailer
            int rowsAffected = 0; 
            bool returnStatus;
            string connectionString = GetConnectionString();
            string SqlStatement = "INSERT INTO movies "+
                "VALUES(@movie_number,@movie_title,@description,@movie_year_made,@genre_id,@movie_rating,@image,@rental_duration,@trailer)";


            try
            {
                using(IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@movie_number", movie.Movie_Number, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@movie_title", movie.Movie_Title, DbType.String, ParameterDirection.Input);
                    parameters.Add("@description", movie.Description, DbType.String, ParameterDirection.Input);
                    parameters.Add("@movie_year_made", movie.Movie_Year_Made, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@genre_id", movie.Genre_Id, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@movie_rating", movie.Movie_Rating, DbType.String, ParameterDirection.Input);
                    parameters.Add("@image", movie.Image, DbType.String, ParameterDirection.Input);
                    parameters.Add("@rental_duration", movie.Rental_Duration, DbType.String, ParameterDirection.Input);
                    parameters.Add("@trailer", movie.Trailer, DbType.String, ParameterDirection.Input);

                    rowsAffected = db.Execute(SqlStatement, parameters);
                }
                    
            }
            catch(Exception ex)
            {
                throw ex;
            }

            returnStatus = rowsAffected > 0 ? true : false;

            return returnStatus;
        }
        public static bool UpdateMovie(Movie movie)
        {
            // movie_number, movie_title, description, movie_year_made, genre_id, movie_rating, image, rental_duration, trailer
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string SQLStatement = "UPDATE movies " +
                " SET movie_title = @movie_title, " +
                "   description = @description, " +
                "   movie_year_made = @movie_year_made, " +
                "   genre_id = @genre_id, " +
                "   movie_rating = @movie_rating, " +
                "   image = @image, "+
                "   rental_duration = @rental_duration, " +
                "   trailer = @trailer " +
                " WHERE movie_number = @movie_number";
                
            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@movie_number", movie.Movie_Number, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@movie_title", movie.Movie_Title, DbType.String, ParameterDirection.Input);
                    parameters.Add("@description", movie.Description, DbType.String, ParameterDirection.Input);
                    parameters.Add("@movie_year_made", movie.Movie_Year_Made, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@genre_id", movie.Genre_Id, DbType.Int32, ParameterDirection.Input);
                    parameters.Add("@movie_rating", movie.Movie_Rating, DbType.String, ParameterDirection.Input);
                    parameters.Add("@image", movie.Image, DbType.String, ParameterDirection.Input);
                    parameters.Add("@rental_duration", movie.Rental_Duration, DbType.String, ParameterDirection.Input);
                    parameters.Add("@trailer", movie.Trailer, DbType.String, ParameterDirection.Input);

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
        public static bool DeleteMovie(Movie movie)
        {
            int rowsAffected = 0;
            bool returnStatus;
            string connectionString = GetConnectionString();
            string sqlStatement = "DELETE movies WHERE movie_number = @movie_number";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@movie_number", movie.Movie_Number, DbType.Int32, ParameterDirection.Input);

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
        public static Movie GetMovieByImg(string imgFile, ref bool isSuccess)
        {
            string connectionString = GetConnectionString();
            Movie requestedMovie = new Movie();
            string sqlStatement = "SELECT * FROM movies " +
                " WHERE image = @image";

            try
            {
                using(IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@image", imgFile, DbType.String, ParameterDirection.Input);

                    requestedMovie = db.QuerySingle(sqlStatement, parm);
                }
            }
            catch(Exception ex)
            { throw ex; }

            if (requestedMovie != null)
                isSuccess = true;
            else
                isSuccess = false;

            return requestedMovie;
        }
        public static Movie GetMovieFromWatchList(WatchList wl)
        {
            string connectionString = GetConnectionString();
            string sqlStatement = "SELECT * FROM movies " +
                "  WHERE Movie_number = @movie_number";
            Movie requestedMember = new Movie();

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@movie_id", wl.Movie_Number, DbType.Int32, ParameterDirection.Input);

                    requestedMember = db.QuerySingle(sqlStatement, parm);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return requestedMember;
        }
        public static List<Movie> SearchMovies(string request)
        {
            string connectionString = GetConnectionString();
            string wcRequest = request += "%";
            string sqlCommand = "SELECT * FROM MOVIES " +
                "  WHERE Movie_title = @movie_title OR Movie_title LIKE @movie_title " +
                "  ORDER BY Movie_title";
            List<Movie> movieSearch = new List<Movie>();

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@movie_title", wcRequest, DbType.String, ParameterDirection.Input);

                    movieSearch = db.Query<Movie>(sqlCommand, parm).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return movieSearch;
        }
        public static List<Movie> GetTopTen()
        {
            Movie tMovie = new Movie();
            List<Recomended> topMovies = new List<Recomended>();
            List<Movie> top10 = new List<Movie>();
            string connectionString = GetConnectionString();
            // gets the count of each group of movie titles then returns the top three counts
            string sqlStatement = "SELECT TOP(10) Movie_number, COUNT(*) as num_of_rentals " +
                " FROM Rentals GROUP BY Movie_number ORDER BY num_of_rentals DESC ";

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    topMovies = db.Query<Recomended>(sqlStatement).ToList();
                }
                
                for (int indx = 0; indx <= topMovies.Count; indx++)
                {
                    top10[indx] = GetRecomended(topMovies[indx]);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return top10;
        }
        public static Movie GetRecomended(Recomended recList)
        {
            string connectionString = GetConnectionString();
            string sqlStatement = "SELECT * FROM movies " +
                "  WHERE Movie_id = @movie_id";
            Movie topMovie = new Movie();

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    DynamicParameters parm = new DynamicParameters();
                    parm.Add("@movie_id", recList.Movie_Number, DbType.Int32, ParameterDirection.Input);

                    topMovie = db.QuerySingle(sqlStatement, parm);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return topMovie;
        }
        public static Movie SpGetTopMovies(int movieNum)
        {
            var procedure = "[GetMovieById]";
            string ConnectString = GetConnectionString();
            Movie selectedMovie = new Movie();
            var value = new { id = movieNum };

            try
            {
                using (IDbConnection db = new SqlConnection(ConnectString))
                {
                    selectedMovie = db.QuerySingle<Movie>(procedure, value, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return selectedMovie;
        }
        public static Movie SpGetTopMovies(WatchList topMovie)
        {
            var procedure = "[GetMovieById]";
            string ConnectString = GetConnectionString();
            Movie selectedMovie = new Movie();
            var value = new { id = topMovie.Movie_Number };

            try
            {
                using (IDbConnection db = new SqlConnection(ConnectString))
                {
                    selectedMovie = db.QuerySingle<Movie>(procedure, value, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            { throw ex; }

            return selectedMovie;
        }
        public static List<Movie> SpGetTop3()
        {
            string procedure = "[GetTop3]";
            string ConnectString = GetConnectionString();
            List<WatchList> top3 = new List<WatchList>();
            List<Movie> movies = new List<Movie>();
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectString))
                {
                    top3 = db.Query<WatchList>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }

                if (top3.Count > 0)
                {
                    for (int idx = 0; idx <= top3.Count - 1; idx++)
                    {
                        movies.Add(SpGetTopMovies(top3[idx]));
                    }
                }
                
            }
            catch (Exception ex)
            { throw ex; }

            return movies;
        }
        public static List<Movie> SpGetWatchListMovies(Member member)
        {
            var procedure = "[GetMemberWatchList]";
            var value = new { member = member.Member_Number };
            string ConnectString = GetConnectionString();
            List<WatchList> watchlist = new List<WatchList>();
            List<Movie> movieList = new List<Movie>();

            try
            {
                using (IDbConnection db = new SqlConnection(ConnectString))
                {
                    watchlist = db.Query<WatchList>(procedure, value, commandType: CommandType.StoredProcedure).ToList();
                }

                for (int idx = 0; idx < watchlist.Count; idx++)
                {
                    movieList.Add(SpGetTopMovies(watchlist[idx].Movie_Number));
                }
            }
            catch (Exception ex)
            { throw ex; }

            return movieList;
        }
        public static List<Movie> SpGetRecommended()
        {
            string connectString = GetConnectionString();
            var procedure = "[GetTop10]";
            List<Recomended> recommended = new List<Recomended>();
            List<Movie> top10 = new List<Movie>();

            try
            {
                using (IDbConnection db = new SqlConnection(connectString))
                {
                    recommended = db.Query<Recomended>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }
                
                if (recommended.Count > 0)
                {
                    for (int indx = 0; indx <= recommended.Count - 1; indx++)
                    {
                        top10.Add(SpGetMovieById(recommended[indx].Movie_Number));
                    }
                }           
            }
            catch(Exception ex)
            { throw ex; }

            return top10;
        }
        public static Movie SpGetMovieById(int movieNumber)
        {
            string conStr = GetConnectionString();
            var procedure = "[GetMovieById]";
            var value = new { id = movieNumber };
            Movie requestedMovie = new Movie();

            try
            {
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    requestedMovie = db.QuerySingle<Movie>(procedure, value, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            { throw ex; }

            return requestedMovie;
        }
        public static List<Movie> SpGetMovieByGenreId(int genreId)
        {
            string connectionString = GetConnectionString();
            var procedure = "[GetMoviesByGenreId]";
            var value = new { id = genreId };
            List<Movie> movieList = new List<Movie>();

            try
            {
                using (IDbConnection db = new SqlConnection(connectionString))
                {
                    movieList = db.Query<Movie>(procedure, value, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { throw ex; }

            return movieList;
        }
        public static List<Movie> SpGetMovie(string movieTitle)
        {
            string conStr = GetConnectionString();
            var procedure = "[GetMovie]";
            var value = new { title = movieTitle };
            List<Movie> movieReq = new List<Movie>();

            try
            {
                using(IDbConnection db = new SqlConnection(conStr))
                {
                    movieReq = db.Query<Movie>(procedure, value, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch(Exception ex)
            { throw ex; }

            return movieReq;
        }
        public static List<Movie> SpGetTop15()
        {
            string conStr = GetConnectionString();
            var procedure = "[GetTop15]";
            List<Recomended> top15 = new List<Recomended>();
            List<Movie> movieReqs = new List<Movie>();

            try
            {
                using (IDbConnection db = new SqlConnection(conStr))
                {
                    top15 = db.Query<Recomended>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }

                if (top15.Count > 0)
                {
                    for (int indx = 0; indx <= top15.Count - 1; indx++)
                    {
                        movieReqs.Add(SpGetMovieById(top15[indx].Movie_Number));
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }

            return movieReqs;
        }
        public static int GetNextMovieNumber()
        {
            string connectString = GetConnectionString();
            var procedure = "[GetAllMovies]";
            List<Movie> movieNumbers = new List<Movie>();
            int NextMovieNumber;
            try
            {
                using (IDbConnection db = new SqlConnection(connectString))
                {
                    movieNumbers = db.Query<Movie>(procedure, commandType: CommandType.StoredProcedure).ToList();
                }

                NextMovieNumber = movieNumbers.Count + 1;
            }
            catch (Exception ex)
            { throw ex; }

            return NextMovieNumber;
        }
    }
}
