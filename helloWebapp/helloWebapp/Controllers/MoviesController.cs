﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using helloWebapp.Models;

namespace helloWebapp.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        //here it is returning Action result,though it is returning a view. But here we have written ActionResult.
        //We can also write it as public ViewResult 
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Sherek"

            };
            return View(movie);
            //return Content("HELLO ASHRAF");
            //to rederect to any page i need to write 
            //return RedirectToAction("Page","Controller");
            //  return RedirectToAction("Index", "Home");
        }
        public ActionResult Edit(int id) {
            return Content("id=" + id);
        }
        //Attribute routing
       // [Route("movies/released/{year}/{month:regex(\\d{4}:range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month) {
            return Content(year+"/"+month);
        }         
        
    }
}