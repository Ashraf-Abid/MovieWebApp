using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using helloWebapp.Models;
using helloWebapp.ViewModels;

namespace helloWebapp.Controllers
{
    public class MoviesController : Controller
    {
        public ViewResult Index()
        {
            var movies = GetMovies();

            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }
        // GET: Movies
        //here it is returning Action result,though it is returning a view. But here we have written ActionResult.
        //We can also write it as public ViewResult 
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Sherek"
            };
            var customers = new List<Customer>
            {
                new Customer{ Name="Custome1"},
                new Customer{Name="Customer2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers

            };

            return View(viewModel);
            //return Content("HELLO ASHRAF");
            //to rederect to any page i need to write 
            //return RedirectToAction("Page","Controller");
            //return RedirectToAction("Index", "Home");
        }
       /* public ActionResult Edit(int id) {
            return Content("id=" + id);
        }*/
        //Attribute routing
       // [Route("movies/released/{year}/{month:regex(\\d{4}:range(1,12)}")]
        /*public ActionResult ByReleaseDate(int year,int month) {
            return Content(year+"/"+month);
        } */        
        
    }
}