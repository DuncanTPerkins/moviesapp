using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public interface Movie
    {
        String ImdbId { get; set; }
        string Title { get; set; }
        DateTime? Year { get; set; }
        string Rated { get; set; }
        DateTime? Released { get; set; }
        String Genre { get; set; }
        String Director { get; set; }
        String Writer { get; set; }
        List<Actor> Actors { get; set; }
        List<ITag> MovieTags { get; set; }
        String Plot { get; set; }
        String Language { get; set; }
        String Country { get; set; }
        String Awards { get; set; }
        String Poster { get; set; }
        int Metascore { get; set; }
        String ImdbRating { get; set; }
        String ImdbVotes { get; set; }
        String Type { get; set; }
        String Response { get; set; }
        int Favorited { get; set; }
        int Watched { get; set; }
    }
}