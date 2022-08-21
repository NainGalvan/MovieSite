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


            model.Movies = GetPopularMovies();


            return View(model);
        }
        public ActionResult TopRated()
        {
            dynamic model = new ExpandoObject();
            model.TopRated = GetTopRated();
            return View(model);
        }
        public ActionResult NowPlaying()
        {

            dynamic model = new ExpandoObject();
            model.NowPlaying = GetNowPlaying();

            return View(model);
        }
        public ActionResult UpComing()
        {

            dynamic model = new ExpandoObject();
            model.UpComing = GetUpComing();

            return View(model);
        }
        public List<Movie> GetPopularMovies()
        {
            string baseUrl = "https://api.themoviedb.org/3/movie/popular?api_key=1bea2c031daeaac81b81720c036771b4";
            Movies popular_result = new Movies();

            var client1 = new HttpClient();
            HttpResponseMessage res1 = client1.GetAsync(baseUrl).Result;


            if (res1.IsSuccessStatusCode)
            {
                var MoviesResponse = res1.Content.ReadAsStringAsync().Result;


                popular_result = JsonConvert.DeserializeObject<Movies>(MoviesResponse);


            }

            // Used to get more indepth information about the popular movies
            List<Movie> movies = new List<Movie>();
            foreach (var movie_result in popular_result.results)
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

        public List<Movie> GetTopRated()
        {
            string baseUrl = "https://api.themoviedb.org/3/movie/top_rated?api_key=1bea2c031daeaac81b81720c036771b4";
            Movies top_rated_result = new Movies();
            var client1 = new HttpClient();
            HttpResponseMessage res1 = client1.GetAsync(baseUrl).Result;


            if (res1.IsSuccessStatusCode)
            {
                var MoviesResponse = res1.Content.ReadAsStringAsync().Result;


                top_rated_result = JsonConvert.DeserializeObject<Movies>(MoviesResponse);


            }
            // Used to get more indepth information about the popular movies
            List<Movie> movies = new List<Movie>();
            foreach (var movie_result in top_rated_result.results)
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

        public List<Movie> GetNowPlaying()
        {
            string baseUrl = "https://api.themoviedb.org/3/movie/now_playing?api_key=1bea2c031daeaac81b81720c036771b4";
            Movies now_playin_result = new Movies();
            var client1 = new HttpClient();
            HttpResponseMessage res1 = client1.GetAsync(baseUrl).Result;


            if (res1.IsSuccessStatusCode)
            {
                var MoviesResponse = res1.Content.ReadAsStringAsync().Result;


                now_playin_result = JsonConvert.DeserializeObject<Movies>(MoviesResponse);


            }
            // Used to get more indepth information about the popular movies
            List<Movie> movies = new List<Movie>();
            foreach (var movie_result in now_playin_result.results)
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

        public List<Movie> GetUpComing()
        {
            string baseUrl = "https://api.themoviedb.org/3/movie/upcoming?api_key=1bea2c031daeaac81b81720c036771b4";
            Movies up_coming_result = new Movies();
            var client1 = new HttpClient();
            HttpResponseMessage res1 = client1.GetAsync(baseUrl).Result;


            if (res1.IsSuccessStatusCode)
            {
                var MoviesResponse = res1.Content.ReadAsStringAsync().Result;


                up_coming_result = JsonConvert.DeserializeObject<Movies>(MoviesResponse);


            }
            // Used to get more indepth information about the popular movies
            List<Movie> movies = new List<Movie>();
            foreach (var movie_result in up_coming_result.results)
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