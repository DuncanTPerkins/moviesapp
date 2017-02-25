using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MoviesApp.Models
{
    [DataContract]
    public class Movie
    {
        public Movie()
        {
            this.Actors = new List<Actor>();
            this.MovieTags = new List<MovieTag>();
        }

        [DataMember]
        public String ImdbId { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public DateTime? Year { get; set; }
        [DataMember]
        public string Rated { get; set; }
        [DataMember]
        public DateTime? Released { get; set; }
        [DataMember]
        public String Genre { get; set; }
        [DataMember]
        public String Director { get; set; }
        [DataMember]
        public String Writer { get; set; }
        [DataMember]
        public List<Actor> Actors { get; set; }
        [DataMember]
        public List<MovieTag> MovieTags { get; set; }
        [DataMember]
        public String Plot { get; set; }
        [DataMember]
        public String Language { get; set; }
        [DataMember]
        public String Country { get; set; }
        [DataMember]
        public String Awards { get; set; }
        [DataMember]
        public String Poster { get; set; }
        [DataMember]
        public int Metascore { get; set; }
        [DataMember]
        public String ImdbRating { get; set; }
        [DataMember]
        public String ImdbVotes { get; set; }
        [DataMember]
        public String Type { get; set; }
        [DataMember]
        public String Response { get; set; }
        [DataMember]
        public int Favorited { get; set; }
        [DataMember]
        public int Watched { get; set; }
    }
}