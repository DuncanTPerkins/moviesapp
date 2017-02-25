using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesApp.Models;
using MoviesApp.AppTier.Bridge.BizService;

namespace MoviesApp.AppTier.Bridge
{
    public class MovieTagCoupler : IMovieTagCoupler
    {
        private IBizService _bizservice;

        public MovieTagCoupler(IBizService bizservice)
        {
            _bizservice = bizservice;
        }
        public MovieTag CreateTag(MovieTag movietag, string movieid)
        {
            return _bizservice.CreateMovieTag(movietag, movieid);
        }

        public void DeleteTagRelationship(MovieTag movietag, string movieid)
        {
            _bizservice.DeleteMovieTagRelationship(movietag, movieid);
        }

        public List<MovieTag> GetAllTags()
        {
            return _bizservice.GetAllMovieTags();
        }

        public MovieTag GetById(int id)
        {
            return _bizservice.GetMovieTagById(id);
        }

        public List<MovieTag> GetByMovie(string id)
        {
            return _bizservice.GetByMovie(id);
        }

        public MovieTag UpdateTag(MovieTag movietag)
        {
            throw new NotImplementedException();
        }
    }
}
