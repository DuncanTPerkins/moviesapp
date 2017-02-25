using MoviesApp.DataTier;
using MoviesApp.Models;
using System.Collections.Generic;
using MoviesApp.BizTier.Bridge;

namespace MoviesApp.BizTier
{
    public class MovieTagProcessor: IMovieTagProcessor
    {
        private IMovieTagConnector _movietagconnector;
        public MovieTagProcessor(IMovieTagConnector movietagconnector)
        {
            _movietagconnector = movietagconnector;
        }
        public MovieTag GetById(int id)
        {
            return _movietagconnector.GetById(id);
        }

        public List<MovieTag> GetByMovie(string id)
        {
            return _movietagconnector.GetByMovie(id);
        }

        public List<MovieTag> GetAllTags()
        {
            return _movietagconnector.GetAllTags();
        }

        public MovieTag CreateTag(MovieTag movietag, string movieid)
        {
            return _movietagconnector.CreateTag(movietag, movieid);
        }

        public MovieTag UpdateTag(MovieTag movietag)
        {
            return _movietagconnector.UpdateTag(movietag);
        }

        public void DeleteTagRelationship(MovieTag movietag, string movieid)
        {
            _movietagconnector.DeleteTagRelationship(movietag, movieid);
        }
    }
}
