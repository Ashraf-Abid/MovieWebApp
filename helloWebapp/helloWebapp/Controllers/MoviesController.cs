using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using helloWebapp.Models;
using helloWebapp.ViewModels;
using System.Data.Entity;

namespace helloWebapp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        //here it is returning Action result,though it is returning a view. But here we have written ActionResult.
        //We can also write it as public ViewResult 
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var movies = _context.movies.Include(c => c.Genre).ToList();
            return View(movies);
        
        }
        public ActionResult New() {
            var GenreTypes = _context.genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                genres = GenreTypes,

            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Movie movie) {
            // _context.movies.Add(movie.modelView);
            /*var movieInDb = _context.movies.Single(m => m.ID == movie.ID);
            movieInDb.Name = movie.Name;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            _context.SaveChanges();
           */
            movie.DateAdded = DateTime.Now;
           // movie.ReleaseDate = DateTime.Now.AddDays(-5);

            _context.movies.Add(movie);
             _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ActionResult New2(int id) {
            var Movie = _context.movies.SingleOrDefault(c => c.ID == id);
            var viewModel = new MovieFormViewModel
            {
                movie = Movie,
                genres = _context.genres.ToList()
              
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Update(Movie movie)
        {
            var movieInDb = _context.movies.Single(c => c.ID == movie.ID);
            movieInDb.Name = movie.Name;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");

        }

        public ActionResult Details(int id) {
            var movie = _context.movies.Include(c => c.Genre).SingleOrDefault(c => c.ID == id);
            if (movie == null) return HttpNotFound();

            return View(movie);
        }
        /*private IEnumerable<Movie> getMovie() { 
        return new List<Movie> {
                new Movie {Name="Bedona",ID=1 },
                new Movie { Name="jontrona",ID=2}
            };
        }
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Sherek"
            };
            var customers = new List<Models.Customer>
            {
                new Models.Customer{ Name="Custome1"},
                new Models.Customer{ Name="Customer2"}
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
        public ActionResult Edit(int id) {
            return Content("id=" + id);
        }
        //Attribute routing
       // [Route("movies/released/{year}/{month:regex(\\d{4}:range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month) {
            return Content(year+"/"+month);
        }         
        */
    }
}