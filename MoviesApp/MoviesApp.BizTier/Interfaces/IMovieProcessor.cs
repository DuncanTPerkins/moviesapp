using MoviesApp.Models;
using System.Collections.Generic;

namespace MoviesApp.BizTier
{
    public interface IMovieProcessor : IBaseProcessor
    {

        Movie GetById(string id);

        List<Movie> GetAllMovies();

        Movie GetByTitle(string title);

        Movie CreateMovie(OmdbMovie omdbmovie);
    }
}
