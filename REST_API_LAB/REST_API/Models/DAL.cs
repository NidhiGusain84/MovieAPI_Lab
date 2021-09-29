using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace REST_API.Models
{
    public class DAL
    {
        public static MySqlConnection DB;

        public static List<Movie> GetAllMovies()
        {
            return DB.GetAll<Movie>().ToList();
        }

        public static Movie GetMovie(int id)
        {
            return DB.Get<Movie>(id);
        }

        public static List<Movie>GetAllForCategory(String theCatId)
        {
            var keyvalues = new { catId = theCatId };
            string sql = "select * from movie where category = @catId";
            return DB.Query<Movie>(sql, keyvalues).ToList();
        }

        public static Movie UpdateMovie(Movie movie)
        {
            DB.Update<Movie>(movie);
            return movie;
        }

        public static Movie AddMovie(Movie movie)
        {
            DB.Insert<Movie>(movie);
            return movie;
        }

        public static bool DeleteMovie(int id)
        {
            Movie movie = new Movie() { Id = id };
            DB.Delete<Movie>(movie);
            return true;
        }

        public static List<string> GetCategories()  //Get a list of all movie categories
        {            
            string sql = "select category from movie";
            return DB.Query<string>(sql).ToList();
        }

        public static List<Movie> GetMovieByName(string name)
        {
            var keyvalue = new { theName = name };          //Get info about a specific movie. User specifies title as a query parameter
            string sql = "select * from movie where name like @theName";
            return DB.Query<Movie>(sql, keyvalue).ToList();
        }

        public static List<Movie> GetByKeyword(string str)
        {
            var keyvalue = new { theStr = str };    //Get a list of movies which have a keyword in their title. User specifies title as a query parameter
            string sql = "select * from movie where name like @theStr";
            return DB.Query<Movie>(sql, keyvalue).ToList();
        }

    }
}
