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

namespace MovieSite.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

        

        string genreUrl = "https://api.themoviedb.org/3/genre/movie/list?api_key=1bea2c031daeaac81b81720c036771b4&language=en-US";


        public ActionResult Popular()
        {
            string baseUrl = "https://api.themoviedb.org/3/movie/popular?api_key=1bea2c031daeaac81b81720c036771b4";
            Movies result = new Movies();

            var client1 = new HttpClient();
            HttpResponseMessage res1 = client1.GetAsync(baseUrl).Result;


            if (res1.IsSuccessStatusCode)
            {
                var MoviesResponse = res1.Content.ReadAsStringAsync().Result;


                result = JsonConvert.DeserializeObject<Movies>(MoviesResponse);


            }

            return View(result.results);
        }

        public ActionResult PopularByPage(int? pageNum)
        {
            int page = (pageNum ?? 1);
            string baseUrl = "https://api.themoviedb.org/3/movie/popular?api_key=1bea2c031daeaac81b81720c036771b4&page=" + page;
            Movies result = new Movies();

            var client1 = new HttpClient();
            HttpResponseMessage res1 = client1.GetAsync(baseUrl).Result;


            if (res1.IsSuccessStatusCode)
            {
                var MoviesResponse = res1.Content.ReadAsStringAsync().Result;


                result = JsonConvert.DeserializeObject<Movies>(MoviesResponse);


            }
           
            return View(result);
        }

        public ActionResult Genre()
        {
            Genres result = new Genres();
 
            var client1 = new HttpClient();
            HttpResponseMessage res1 = client1.GetAsync(genreUrl).Result;


            if (res1.IsSuccessStatusCode)
            {
                var MoviesResponse = res1.Content.ReadAsStringAsync().Result;


                result = JsonConvert.DeserializeObject<Genres>(MoviesResponse);
            }
            return View(result);

        }
    }

    
}