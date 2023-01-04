using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{

    //atenção com a HERANÇA DA CONTROLLER
    public class ProductsController : Controller
    {

        Movie[] movies = new Movie[]
        {
            new Movie { Id = 1, Name = "Simpsons 123", Cat = "Desenho", Price= 60.60M },
            new Movie { Id = 2, Name = "Star Wars 456", Cat = "Sci-Fi", Price = 15.75M },
            new Movie { Id = 3, Name = "Transformers 789", Cat = "Ação", Price = 14.90M }
        };


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






        // GET: ProductsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
