using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public class OmdbMovie
    {
        public string Title { get; set; }
        public String Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public String Genre { get; set; }
        public String Director { get; set; }
        public String Writer { get; set; }
        public String Actors { get; set; }
        public String  Plot { get; set; }
        public String Language { get; set; }
        public String Country { get; set; }
        public String Awards { get; set; }
        public String Poster { get; set; }
        public int Metascore { get; set; }
        public String ImdbRating { get; set; }
        public String ImdbVotes { get; set; }
        public String ImdbID { get; set; }
        public String Type { get; set; }
        public String Response { get; set; }

    }
}