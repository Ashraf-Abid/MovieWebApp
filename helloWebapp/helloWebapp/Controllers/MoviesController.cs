﻿using System;
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