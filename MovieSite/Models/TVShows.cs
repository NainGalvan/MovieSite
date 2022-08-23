using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieSite.Models
{
    // Used to get popular/top_rated/upcoming/nowplaying tv shows
    // The results dont have much information about
    // the tvshows so we use tvshow class for more in depth information by using the ids obtained in the results
    public class TVShows
    {
        public int page { get; set; }
        public TVShow_Result[] results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }

    public class TVShow_Result
    {
        public int id { get; set; }
    }

}