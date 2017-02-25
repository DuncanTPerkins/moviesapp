using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MoviesApp.DataTier.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DataService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DataService.svc or DataService.svc.cs at the Solution Explorer and start debugging.
    public class DataService : IDataService
    {
        private IActorProvider _actorprovider;
        private IMovieProvider _movieprovider;
        private IActorTagProvider _actortagprovider;
        private IMovieTagProvider _movietagprovider;

        public DataService(IActorProvider actorprovider, IMovieProvider movieprovider,
            IActorTagProvider actortagprovider, IMovieTagProvider movietagprovider)
        {
            _actorprovider = actorprovider;
            _movieprovider = movieprovider;
            _actortagprovider = actortagprovider;
            _movietagprovider = movietagprovider;
        }

        #region Actor

        public Actor GetActorById(int id)
        {
            return _actorprovider.GetById(id);
        }

        public List<Actor> GetAllActors()
        {
            return _actorprovider.GetAllActors();
        }

        public Actor GetByName(string name)
        {
            return _actorprovider.GetByName(name);
        }

        public Actor CreateActor(Actor actor)
        {
            return _actorprovider.CreateActor(actor);
        }

        #endregion

        #region Movies

        public Movie GetMovieById(string id)
        {
            return _movieprovider.GetById(id);
        }

        public List<Movie> GetAllMovies()
        {
            return _movieprovider.GetAllMovies();
        }

        public Movie GetByTitle(string title)
        {
            return _movieprovider.GetByTitle(title);
        }

        public Movie CreateMovie(Movie movie)
        {
            return _movieprovider.CreateMovie(movie);
        }

        #endregion

        #region ActorTags

        public ActorTag GetActorTagById(int id)
        {
            return _actortagprovider.GetById(id);
        }

        public List<ActorTag> GetAllActorTags()
        {
            return _actortagprovider.GetAllTags();
        }

        public ActorTag CreateActorTag(ActorTag actortag, int actorid)
        {
            return _actortagprovider.CreateTag(actortag, actorid);
        }

        public ActorTag UpdateActorTag(ActorTag actortag)
        {
            return _actortagprovider.UpdateTag(actortag);
        }

        public void DeleteActorTagRelationship(ActorTag actortag, int actorid)
        {
            _actortagprovider.DeleteTagRelationship(actortag, actorid);
        }

        #endregion

        #region MovieTags

        public MovieTag GetMovieTagById(int id)
        {
            return _movietagprovider.GetById(id);
        }

        public List<MovieTag> GetAllMovieTags()
        {
            return _movietagprovider.GetAllTags();
        }

        public MovieTag CreateMovieTag(MovieTag movietag, string movieid)
        {
            return _movietagprovider.CreateTag(movietag, movieid);
        }

        public List<MovieTag> GetByMovie(string id)
        {
            return _movietagprovider.GetByMovie(id);
        }

        public MovieTag UpdateMovieTag(MovieTag movietag)
        {
            return _movietagprovider.UpdateTag(movietag);
        }

        public void DeleteMovieTagRelationship(MovieTag movietag, String movieid)
        {
            _movietagprovider.DeleteTagRelationship(movietag, movieid);
        }


        #endregion
    }
}
