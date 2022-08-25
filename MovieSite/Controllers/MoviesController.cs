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
        public ActionResult Index(int?page)
        {

            dynamic model = new ExpandoObject();
           
            Console.WriteLine("index " + page);
            var movies = GetMovies("popular",page);

            model.Page = movies.page;
            model.Total_Page = 10;
            model.Movies = GetMovieDetails(movies);

            
            return View("_movieLayout",model);
        }
        public ActionResult TopRated(int?page)
        {
            dynamic model = new ExpandoObject();
            var TopRated = GetMovies("top_rated",page);
            model.Page = TopRated.page;
            model.Total_Page = 10;
            model.Movies = GetMovieDetails(TopRated);

            
            return View("_movieLayout", model);
        }
        public ActionResult NowPlaying(int?page)
        {

            dynamic model = new ExpandoObject();
  
            var NowPlaying = GetMovies("now_playing",page);
            model.Page = NowPlaying.page;
            model.Total_Page = 10;
            model.Movies = GetMovieDetails(NowPlaying);


            return View("_movieLayout", model);
        }
        public ActionResult UpComing(int?page)
        {

            dynamic model = new ExpandoObject();
            var UpComing = GetMovies("upcoming",page);
            model.Page = UpComing.page;
            model.Total_Page = 10;
            model.Movies = GetMovieDetails(UpComing);


            return View("_movieLayout", model);
        }

        public ActionResult Watch(string id)
        {
            string detailUrl = "https://api.themoviedb.org/3/movie/" + id + "?api_key=1bea2c031daeaac81b81720c036771b4";
            Movie movie = new Movie();

            var client2 = new HttpClient();
            HttpResponseMessage res2 = client2.GetAsync(detailUrl).Result;

            if (res2.IsSuccessStatusCode)
            {
                var response = res2.Content.ReadAsStringAsync().Result;
                movie = JsonConvert.DeserializeObject<Movie>(response);
            }

            dynamic model = new ExpandoObject();
            model.Movie = movie;

            return View(model);
        }

        
        public List<Movie> GetMovieDetails(Movies result)
        {
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
                    movie.page = result.page;
                    movie.total_pages = result.total_pages;
                    movies.Add(movie);

                }
            }
            return movies;
        }
        public Movies GetMovies(string search, int?page) 
        {
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            string baseUrl = "https://api.themoviedb.org/3/movie/" + search + "?api_key=1bea2c031daeaac81b81720c036771b4&page=" + pageIndex;
            Movies result = new Movies();
            System.Diagnostics.Debug.WriteLine(baseUrl);


            var client = new HttpClient();
            HttpResponseMessage res = client.GetAsync(baseUrl).Result;

            if (res.IsSuccessStatusCode)
            {
                var MoviesResponse = res.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<Movies>(MoviesResponse);
            }

            
            return result;

        }
    }
}

