using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("movies")]
    [ApiController]
    public class ProductsAPIController : ControllerBase
    {
        /*  private readonly IFilmeServiceInterface service;

         public ProductsAPIController(IFilmeServiceInterface service)
          {
              this.service = service;
          }

          [Microsoft.AspNetCore.Mvc.HttpGet()]
          public IActionResult Get()
          {
              var model = service.GetFilmes();

              var outputModel = ToOutputModel(model);
              return Ok(outputModel);
          }

          [Microsoft.AspNetCore.Mvc.HttpGet("{id}", Name = "GetFilme")]
          public IActionResult Get(int id)
          {
              var model = service.GetFilme(id);
              if (model == null)
                  return NotFound();

              var outputModel = ToOutputModel(model);
              return Ok(outputModel);
          }

          [Microsoft.AspNetCore.Mvc.HttpPost]
          public IActionResult Create([Microsoft.AspNetCore.Mvc.FromBody] MovieInputModel inputModel)
          {
              if (inputModel == null)
                  return BadRequest();

              var model = ToDomainModel(inputModel);
              service.AddFilme(model);

              var outputModel = ToOutputModel(model);
              return CreatedAtRoute("GetFilme", new { id = outputModel.Id }, outputModel);
          }

          [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
          public IActionResult Update(int id, [Microsoft.AspNetCore.Mvc.FromBody] MovieInputModel inputModel)
          {
              if (inputModel == null || id != inputModel.Id)
                  return BadRequest();

              if (!service.FilmeExists(id))
                  return NotFound();

              var model = ToDomainModel(inputModel);
              service.UpdateFilme(model);

              return NoContent();
          }

          [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
          public IActionResult Delete(int id)
          {
              if (!service.FilmeExists(id))
                  return NotFound();

              service.DeleteFilme(id);

              return NoContent();
          }

          //--------------------------------------------------
          //Mapeamentos : modelos envia/recebe dados via API
          private MovieOutputModel ToOutputModel(Movie model)
          {
              return new MovieOutputModel
              {
                  Id = model.Id,
                  Name = model.Name,
                  Year = model.Year,
                  Resume = model.Resume,
                  //UltimoAcesso = DateTime.Now
              };
          }

          private List<MovieOutputModel> ToOutputModel(List<Movie> model)
          {
              return model.Select(item => ToOutputModel(item)).ToList();
          }

          private Movie ToDomainModel(MovieInputModel inputModel)
          {
              return new Movie
              {
                  Id = inputModel.Id,
                  Name = inputModel.Name,
                  Year = inputModel.Year,
                  Resume = inputModel.Resume
              };
          }

          private MovieInputModel ToInputModel(Movie model)
          {
              return new MovieInputModel
              {
                  Id = model.Id,
                  Name = model.Name,
                  Year = model.Year,
                  Resume = model.Resume
              };
          }

          */

        Movie[] movies = new Movie[]
        {
            new Movie { Id = 1, Name = "Movie 123", Cat = "Sci-Fi", Price= 45.60M },
            new Movie { Id = 2, Name = "Movie 456", Cat = "Drama", Price = 23.75M },
            new Movie { Id = 3, Name = "Movie789", Cat = "Ação", Price = 19.90M }
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

        //[Microsoft.AspNetCore.Mvc.HttpGet("{cat}")]
        public IEnumerable<Movie> GetMovieByCat(string cat)
        {
            return movies.Where((p) => string.Equals(p.Cat, cat, StringComparison.OrdinalIgnoreCase));
        }






    }
}

