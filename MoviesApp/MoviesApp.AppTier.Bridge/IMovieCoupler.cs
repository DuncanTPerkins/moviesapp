using System.Collections.Generic;
using MoviesApp.Models;

namespace MoviesApp.AppTier.Bridge
{
    public interface IMovieCoupler
    {
        Movie GetById(string id);
        List<Movie> GetAllMovies();
        Movie GetByTitle(string title);
        Movie CreateMovie(OmdbMovie omdbmovie);
    }
}
