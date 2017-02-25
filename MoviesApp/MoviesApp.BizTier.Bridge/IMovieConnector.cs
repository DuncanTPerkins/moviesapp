using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.BizTier.Bridge
{
    public interface IMovieConnector
    {
        Movie GetById(string id);
        List<Movie> GetAllMovies();
        Movie GetByTitle(string title);
        Movie CreateMovie(Movie movie);
    }
}
