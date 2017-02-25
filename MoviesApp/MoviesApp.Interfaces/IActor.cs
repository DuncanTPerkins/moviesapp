using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesApp.Models
{
    public interface Actor
    {      
        int ActorId { get; set; }
        String Name { get; set; }
        List<Movie> Movies { get; set; }
        List<ITag> ActorTags { get; set; }
        int Favorited { get; set; }
    }
}