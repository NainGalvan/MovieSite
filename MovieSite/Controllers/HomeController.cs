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
            dynamic model = new ExpandoObject();


            model.Movies = new MoviesController().GetMovie();

            /*ViewResult viewResult1 = (ViewResult)new MoviesController().Genre();
            
            ViewResult viewResult2 = (ViewResult)new MoviesController().Popular();
            model.Popular = viewResult2.Model;
            model.Genre = viewResult1.Model;*/


            /*foreach(var movie in model.Popular)
            {
                List<string> genres = new List<string>();

                foreach (var genre_id in movie.genre_ids)
                {
                    foreach (var genre in model.Genre.genres)
                    {
                        if(genre_id == genre.id)
                        {
                            genres.Add(genre.name);
                            movie.genres = genres;
                            break;
                        }
                      }
                }
            }*/

            return View(model);
        }

       
       /* public Result[] Popular()
        {
            Movies result = new Movies();

            var client1 = new HttpClient();
            HttpResponseMessage res1 = client1.GetAsync(baseUrl).Result;


            if (res1.IsSuccessStatusCode)
            {
                var MoviesResponse = res1.Content.ReadAsStringAsync().Result;


                result = JsonConvert.DeserializeObject<Movies>(MoviesResponse);


            }
            return result.results;
        }*/

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}