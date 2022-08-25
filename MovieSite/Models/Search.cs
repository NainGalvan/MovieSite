using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieSite.Models
{

    public class Search
    {
        public int page { get; set; }
        public Search_Result[] results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }

    public class Search_Result
    {

        public int id { get; set; }
        public string media_type { get; set; }

    }

  

}