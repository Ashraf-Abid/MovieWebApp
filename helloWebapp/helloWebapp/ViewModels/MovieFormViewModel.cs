using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using helloWebapp.Models;

namespace helloWebapp.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> genres  { get; set; }
        public Movie movie { get; set; }
    }
}