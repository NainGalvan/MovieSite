using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieSite.Models;
using System.Dynamic;
using System.Net.Http;
using Newtonsoft.Json;
using PagedList;

namespace MovieSite.Controllers
{
    public class TVShowsController : Controller
    {
        // GET: TVShows
        public ActionResult Index(int?page)
        {
            dynamic model = new ExpandoObject();
            var Shows = GetTVShows("popular",page);
            model.Page = Shows.page;
            model.Total_Page = Shows.total_pages;
            model.Shows = GetTVShowsDetail(Shows);
            return View("_TvShowLayout",model);
        }
        public ActionResult TopRated(int?page)
        {
            dynamic model = new ExpandoObject();
            var TopRated = GetTVShows("top_rated",page);
            model.Page = TopRated.page;
            model.Total_Page = TopRated.total_pages;
            model.Shows = GetTVShowsDetail(TopRated);
            return View("_TvShowLayout",model);
        }
        public ActionResult AiringToday(int? page)
        {
            dynamic model = new ExpandoObject();
            var AiringToday = GetTVShows("airing_today", page);
            model.Page = AiringToday.page;
            model.Total_Page = AiringToday.total_pages ;
            model.Shows = GetTVShowsDetail(AiringToday);
            return View("_TvShowLayout",model);
        }
        public ActionResult OnTV(int? page)
        {
            dynamic model = new ExpandoObject();
            var OnTV = GetTVShows("on_the_air",page);
            model.Page = OnTV.page;
            model.Total_Page = OnTV.total_pages;
            model.Shows = GetTVShowsDetail(OnTV);
            return View("_TvShowLayout", model);
        }

        public ActionResult Watch(string id, int?season)
        {
            dynamic model = new ExpandoObject();

            model.Show = GetShowDetail(id);
            
            model.Season = GetSeasonInfo(id,season);
 
            return View(model);
        }

        // Used to get one specific show details
        // Returns one show
        public TVShow GetShowDetail(string id)
        {
            string detailUrl = "https://api.themoviedb.org/3/tv/" + id + "?api_key=1bea2c031daeaac81b81720c036771b4";
            TVShow show = new TVShow();

            var client2 = new HttpClient();
            HttpResponseMessage res2 = client2.GetAsync(detailUrl).Result;

            if (res2.IsSuccessStatusCode)
            {
                var response = res2.Content.ReadAsStringAsync().Result;
                show = JsonConvert.DeserializeObject<TVShow>(response);
            }
            return show;
        }
        
        // Used to get a specific show seasons information such as episodes 
        public TVShowSeason GetSeasonInfo(string show_id, int?seasonVal)
        {
            int seasonIndex = 1;
            seasonIndex = seasonVal.HasValue ? Convert.ToInt32(seasonVal) : 1;
            string baseUrl = "https://api.themoviedb.org/3/tv/" + show_id + "/season/" + seasonIndex + "?api_key=1bea2c031daeaac81b81720c036771b4";
            TVShowSeason show_season = new TVShowSeason();
            List<Episode> episodes = new List<Episode>();
            var client = new HttpClient();
            HttpResponseMessage res = client.GetAsync(baseUrl).Result;
            if (res.IsSuccessStatusCode)
            {
                var season = res.Content.ReadAsStringAsync().Result;
                show_season = JsonConvert.DeserializeObject<TVShowSeason>(season);
            }

            return show_season;
        }
        // Used to get the different type of shows eg: Popular/AiringToday/OnTV/TopRated
        // Returns the result of the search
        public TVShows GetTVShows(string search, int?page)
        {
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            string baseUrl = "https://api.themoviedb.org/3/tv/" + search + "?api_key=1bea2c031daeaac81b81720c036771b4&page=" + pageIndex;
            TVShows result = new TVShows();
            var client = new HttpClient();
            HttpResponseMessage res = client.GetAsync(baseUrl).Result;
            if(res.IsSuccessStatusCode)
            {
                var TvResponse = res.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<TVShows>(TvResponse);
            }
            return result;
        }
        // Used to get multiple shows details and return a list of shows
        public List<TVShow> GetTVShowsDetail(TVShows result)
        {
            List<TVShow> shows = new List<TVShow>();
            if (result.total_results != null)
            {
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
            }
            return shows;
        }
    }
}