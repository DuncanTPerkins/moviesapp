using MoviesApp.Models;
using System.Collections.Generic;
using MoviesApp.BizTier.Bridge.DataService;

namespace MoviesApp.BizTier.Bridge
{
    public class MovieTagConnector: IMovieTagConnector
    {
        private IDataService _dataservice;
        public MovieTagConnector(IDataService dataservice)
        {
            _dataservice = dataservice;
        }
        public MovieTag GetById(int id)
        {
            return _dataservice.GetMovieTagById(id);
        }

        public List<MovieTag> GetByMovie(string id)
        {
            return _dataservice.GetByMovie(id);
        }

        public List<MovieTag> GetAllTags()
        {
            return _dataservice.GetAllMovieTags();
        }

        public MovieTag CreateTag(MovieTag movietag, string movieid)
        {
            return _dataservice.CreateMovieTag(movietag, movieid);
        }

        public MovieTag UpdateTag(MovieTag movietag)
        {
            return _dataservice.UpdateMovieTag(movietag);
        }

        public void DeleteTagRelationship(MovieTag movietag, string movieid)
        {
            _dataservice.DeleteMovieTagRelationship(movietag, movieid);
        }
    }
}
