using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieSite.Models
{
    // Used to get more in depth information about a show seasons through the show id and season number
    public class TVShowSeason
    {
        public string _id { get; set; }
        public string air_date { get; set; }
        public Episode[] episodes { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public int id { get; set; }
        public string poster_path { get; set; }
        public int season_number { get; set; }

    }

    public class Episode
    {
        public string air_date { get; set; }
        public int episode_number { get; set; }
        public Crew[] crew { get; set; }
        public Guest_Stars[] guest_stars { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public string production_code { get; set; }
        public int season_number { get; set; }
        public string still_path { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
    }

    public class Season_Crew
    {
        public string department { get; set; }
        public string job { get; set; }
        public string credit_id { get; set; }
        public bool adult { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public float popularity { get; set; }
        public string profile_path { get; set; }
    }

    public class Season_Guest_Stars
    {
        public string credit_id { get; set; }
        public int order { get; set; }
        public string character { get; set; }
        public bool adult { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string known_for_department { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public float popularity { get; set; }
        public string profile_path { get; set; }
    }

}