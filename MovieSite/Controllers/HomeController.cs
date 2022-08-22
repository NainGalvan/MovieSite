using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MovieSite.Models;
using Newtonsoft.Json;
using System.Dynamic;

namespace MovieSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           /* dynamic model = new ExpandoObject();

            model.Movies = new MoviesController().GetPopularMovies();*/

            return View();
        }
    }
}