using System.Collections.Generic;
using MoviesApp.Models;

namespace MoviesApp.BizTier.Bridge
{
    public interface IMovieTagConnector
    {
        MovieTag GetById(int id);
        List<MovieTag> GetByMovie(string id);
        List<MovieTag> GetAllTags();
        MovieTag CreateTag(MovieTag movietag, string movieid);
        MovieTag UpdateTag(MovieTag movietag);
        void DeleteTagRelationship(MovieTag movietag, string movieid);
    }
}