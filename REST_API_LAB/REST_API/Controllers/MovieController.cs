using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace REST_API.Controllers
{
    [Route("movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet("getall")]
        public List<Movie> GetAll()
        {
            return DAL.GetAllMovies();
        }
        [HttpGet("getone")]
        public Movie GetSingleMovie(int id)
        {
            return DAL.GetMovie(id);
        }

        [HttpGet("category")]
        public List<Movie> GetMoviesInCategory(string cat)
        {
            return DAL.GetAllForCategory(cat);
        }
        [HttpPut("update")]
        public Movie UpdateMovie(Movie movie)
        {
            DAL.UpdateMovie(movie);
            return movie;
        }
        [HttpPost("add")]
        public Movie AddMovie(Movie movie)
        {
           return DAL.AddMovie(movie);
          
        }

        [HttpDelete("delete")]
        public bool DeleteMovie(int id)
        {
            return DAL.DeleteMovie(id);
            
        }

        [HttpGet("categories")]     //Get a list of all movie categories
        public List<string> GetMovieCategories()
        {
            return DAL.GetCategories();
        }

        [HttpGet("getspecific")]
        public List<Movie> GetSpecificMovies(string name)
        {
            return DAL.GetMovieByName(name);
        }

        [HttpGet("keyword")]
        public List<Movie> GetByKeyword(string str)
        {
            return DAL.GetByKeyword(str);
        }

    }
}
