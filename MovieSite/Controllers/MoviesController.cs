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
using PagedList.Mvc;
using PagedList;
using System.Dynamic;

namespace MovieSite.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();


            model.Movies = GetMovies("popular");


            return View(model);
        }
        public ActionResult TopRated()
        {
            dynamic model = new ExpandoObject();
            model.TopRated = GetMovies("top_rated");
            return View(model);
        }
        public ActionResult NowPlaying()
        {

            dynamic model = new ExpandoObject();
            model.NowPlaying = GetMovies("now_playing");

            return View(model);
        }
        public ActionResult UpComing()
        {

            dynamic model = new ExpandoObject();
            model.UpComing = GetMovies("upcoming");

            return View(model);
        }

        public List<Movie> GetMovies(string search) 
        {
            string baseUrl = "https://api.themoviedb.org/3/movie/" + search + "?api_key=1bea2c031daeaac81b81720c036771b4";
            Movies result = new Movies();

            var client = new HttpClient();
            HttpResponseMessage res = client.GetAsync(baseUrl).Result;

            if (res.IsSuccessStatusCode)
            {
                var MoviesResponse = res.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<Movies>(MoviesResponse);
            }

            // Used to get more indepth information about the popular movies
            List<Movie> movies = new List<Movie>();
            foreach (var movie_result in result.results)
            {
                string detailUrl = "https://api.themoviedb.org/3/movie/" + movie_result.id + "?api_key=1bea2c031daeaac81b81720c036771b4";
                Movie movie = new Movie();

                var client2 = new HttpClient();
                HttpResponseMessage res2 = client2.GetAsync(detailUrl).Result;

                if (res2.IsSuccessStatusCode)
                {
                    var response = res2.Content.ReadAsStringAsync().Result;
                    movie = JsonConvert.DeserializeObject<Movie>(response);
                    movies.Add(movie);

                }
            }
            return movies;

        }
    }
}

