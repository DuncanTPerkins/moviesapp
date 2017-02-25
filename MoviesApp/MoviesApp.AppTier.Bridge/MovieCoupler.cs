using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesApp.AppTier.Bridge.BizService;
using MoviesApp.Models;

namespace MoviesApp.AppTier.Bridge
{
    public class MovieCoupler : IMovieCoupler
    {
        private IBizService _bizservice;

        public MovieCoupler(IBizService bizservice)
        {
            _bizservice = bizservice;
        }
        public Movie CreateMovie(OmdbMovie omdbmovie)
        {
            return _bizservice.CreateMovie(omdbmovie);
        }

        public List<Movie> GetAllMovies()
        {
            return _bizservice.GetAllMovies();
        }

        public Movie GetById(string id)
        {
            return _bizservice.GetMovieById(id);
        }

        public Movie GetByTitle(string title)
        {
            return _bizservice.GetByTitle(title);
        }
    }
}
