using System;
using MoviesApp.Models;
using System.Collections.Generic;

namespace MoviesApp.DataTier
{
    public interface IMovieTagProvider: IBaseProvider
    {
        MovieTag GetById(int id);

        List<MovieTag> GetByMovie(string id);

        List<MovieTag> GetAllTags();

        MovieTag CreateTag(MovieTag movietag, string movieid);

        MovieTag UpdateTag(MovieTag movietag);

        void DeleteTagRelationship(MovieTag movietag, String movieid);
    }
}
