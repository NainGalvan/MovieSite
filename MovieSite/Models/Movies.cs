using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieSite.Models
{   // Used to get popular/top_rated/upcoming/nowplaying movies
    // The results dont have much information about
    // the movies so we use Movie class for more in depth information by using the ids obtained in the results
    public class Movies
    {
        public int page { get; set; }
        public Result[] results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }

    public class Result
    {
        public int id { get; set; }
    }
}