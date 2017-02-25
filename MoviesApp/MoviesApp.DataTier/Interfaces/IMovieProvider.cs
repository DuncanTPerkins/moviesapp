using MoviesApp.Models;
using System.Collections.Generic;

namespace MoviesApp.DataTier
{
    public interface IMovieProvider : IBaseProvider
    {

        Movie GetById(string id);

        List<Movie> GetAllMovies();

        Movie GetByTitle(string title);

        Movie CreateMovie(Movie movie);
    }
}
