using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/movies")]
    [ApiController]
    public class ProductsAPIController : ControllerBase
    {
        Movie[] movies = new Movie[]
        {
            new Movie { Id = 1, Name = "Simpsons 123", Cat = "Desenho", Price= 60.60M },
            new Movie { Id = 2, Name = "Star Wars 456", Cat = "Sci-Fi", Price = 15.75M },
            new Movie { Id = 3, Name = "Transformers 789", Cat = "Ação", Price = 14.90M }
        };

        [Microsoft.AspNetCore.Mvc.HttpGet()]
        public IEnumerable<Movie> GetAllMovies()
        {
            return movies;
        }
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public Movie GetMovieById(int id)
        {
            var movie = movies.FirstOrDefault((p) => p.Id == id);
            if (movie == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(resp);
            }
            return movie;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{cat}")]
        public IEnumerable<Movie> GetMovieByCat(string cat)
        {
            return movies.Where((p) => string.Equals(p.Cat, cat, StringComparison.OrdinalIgnoreCase));
        }
    }
}

