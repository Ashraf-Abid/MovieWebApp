using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using helloWebapp.Models;

namespace helloWebapp.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Models.Customer> Customers { get; set; }
    }
}