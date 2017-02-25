using MoviesApp.Models;
using System.Collections.Generic;

namespace MoviesApp.AppTier.Bridge
{
    public interface IMovieTagCoupler
    {
        MovieTag GetById(int id);
        List<MovieTag> GetByMovie(string id);
        List<MovieTag> GetAllTags();
        MovieTag CreateTag(MovieTag movietag, string movieid);
        MovieTag UpdateTag(MovieTag movietag);
        void DeleteTagRelationship(MovieTag movietag, string movieid);
    }
}
