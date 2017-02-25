using MoviesApp.Models;
using System;
using System.Collections.Generic;
using MoviesApp.BizTier.Bridge.DataService;

namespace MoviesApp.BizTier.Bridge
{
    public class MovieConnector: IMovieConnector
    {
        private IDataService _dataservice;
        public MovieConnector(IDataService dataservice)
        {
            _dataservice = dataservice;
        }
        public Movie GetById(string id)
        {
            return _dataservice.GetMovieById(id);
        }

        public List<Movie> GetAllMovies()
        {
            return _dataservice.GetAllMovies();
        }
       
        public Movie GetByTitle(string title)
        {
            return _dataservice.GetByTitle(title);
        }

        public Movie CreateMovie(Movie movie)
        {
            return _dataservice.CreateMovie(movie);
        }
    }
}
