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

        public ActionResult Search(string query, int?page)
        {
            dynamic model = new ExpandoObject();
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            string baseUrl = "https://api/themoviedb.org/3/search/muli" + "?api_key=1bea2c031daeaac81b81720c036771b4&" + query + "&page=" + page;
            
            TVShows resultShow = new TVShows();
            var client1 = new HttpClient();
            HttpResponseMessage res1 = client1.GetAsync(baseUrl).Result;
            if (res1.IsSuccessStatusCode)
            {
                var response = res1.Content.ReadAsStringAsync().Result;
/*                resultShow = JsonConvert.DeserializeObject<TVShows>(response);
*/            }

           /* model.Page = resultShow.page;
            model.Total_Page = resultShow.total_pages;
            model.Shows = new TVShowsController().GetTVShowsDetail(resultShow);


            Movies resultMovie = new Movies();


            var client2 = new HttpClient();
            HttpResponseMessage res2 = client2.GetAsync(baseUrl).Result;

            if (res2.IsSuccessStatusCode)
            {
                var MoviesResponse = res2.Content.ReadAsStringAsync().Result;
                resultMovie = JsonConvert.DeserializeObject<Movies>(MoviesResponse);
            }

            model.Page = resultMovie.page;
            model.Total_Page = resultMovie.total_pages;
            model.Movies = new MoviesController().GetMovieDetails(resultMovie);*/

            return View("_MovieLayout", model);
        }
    }
}