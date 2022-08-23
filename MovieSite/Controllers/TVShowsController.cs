using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieSite.Models;
using System.Dynamic;
using System.Net.Http;
using Newtonsoft.Json;

namespace MovieSite.Controllers
{
    public class TVShowsController : Controller
    {
        // GET: TVShows
        public ActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Shows = GetTVShows("popular");
            return View(model);
        }
        public ActionResult TopRated()
        {
            dynamic model = new ExpandoObject();
            model.TopRated = GetTVShows("top_rated");
            return View(model);
        }
        public ActionResult AiringToday()
        {
            dynamic model = new ExpandoObject();
            model.AiringToday = GetTVShows("airing_today");
            return View(model);
        }
        public ActionResult OnTV()
        {
            dynamic model = new ExpandoObject();
            model.OnTV = GetTVShows("on_the_air");
            return View(model);
        }

        public ActionResult Watch(string id)
        {

            dynamic model = new ExpandoObject();
            model.Season = GetSeasonInfo(id);
            
            return View(model);
        }

        public List<Episode> GetSeasonInfo(string show_id)
        {
            string baseUrl = "https://api.themoviedb.org/3/tv/" + show_id + "/season/1?api_key=1bea2c031daeaac81b81720c036771b4";
            TVShowSeason show_season = new TVShowSeason();
            List<Episode> episodes = new List<Episode>();
            var client = new HttpClient();
            HttpResponseMessage res = client.GetAsync(baseUrl).Result;
            if (res.IsSuccessStatusCode)
            {
                var season = res.Content.ReadAsStringAsync().Result;
                show_season = JsonConvert.DeserializeObject<TVShowSeason>(season);
            }
            episodes = show_season.episodes.ToList();

            return episodes;
        }
        public List<TVShow> GetTVShows(string search)
        {
            string baseUrl = "https://api.themoviedb.org/3/tv/" + search + "?api_key=1bea2c031daeaac81b81720c036771b4";
            TVShows result = new TVShows();
            List<TVShow> shows = new List<TVShow>();
            var client = new HttpClient();
            HttpResponseMessage res = client.GetAsync(baseUrl).Result;
            if(res.IsSuccessStatusCode)
            {
                var TvResponse = res.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<TVShows>(TvResponse);
            }
            
            foreach (var show_result in result.results)
            {
                string detailUrl = "https://api.themoviedb.org/3/tv/" + show_result.id + "?api_key=1bea2c031daeaac81b81720c036771b4";
                TVShow show = new TVShow();

                var client2 = new HttpClient();
                HttpResponseMessage res2 = client2.GetAsync(detailUrl).Result;

                if (res2.IsSuccessStatusCode)
                {
                    var response = res2.Content.ReadAsStringAsync().Result;
                    show = JsonConvert.DeserializeObject<TVShow>(response);
                    shows.Add(show);

                }
            }
            return shows;
        }
    }
}