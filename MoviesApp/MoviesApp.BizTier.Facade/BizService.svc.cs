using System;
using System.Collections.Generic;
using MoviesApp.Models;

namespace MoviesApp.BizTier.Facade
{
    public class BizService : IBizService
    {
        private IActorProcessor _actorprocessor;
        private IMovieProcessor _movieprocessor;
        private IActorTagProcessor _actortagprocessor;
        private IMovieTagProcessor _movietagprocessor;

        public BizService(IActorProcessor actorprocessor, IMovieProcessor movieprocessor, IActorTagProcessor actortagprocessor, IMovieTagProcessor movietagprocessor)
        {
            _actorprocessor = actorprocessor;
            _movieprocessor = movieprocessor;
            _actortagprocessor = actortagprocessor;
            _movietagprocessor = movietagprocessor;
        }
        #region Actor
        public Actor GetActorById(int id)
        {
            return _actorprocessor.GetById(id);
        }

        public List<Actor> GetAllActors()
        {
            return _actorprocessor.GetAllActors();
        }

        public Actor GetByName(string name)
        {
            return _actorprocessor.GetByName(name);
        }

        public Actor CreateActor(Actor actor)
        {
            return _actorprocessor.CreateActor(actor);
        }

        public List<Actor> GetActorsByString(string actorstring)
        {
            return _actorprocessor.GetActorsByString(actorstring);
        }
        #endregion

        #region Movies
        public Movie GetMovieById(string id)
        {
            return _movieprocessor.GetById(id);
        }

        public List<Movie> GetAllMovies()
        {
            return _movieprocessor.GetAllMovies();
        }

        public Movie GetByTitle(string title)
        {
            return _movieprocessor.GetByTitle(title);
        }

        public Movie CreateMovie(OmdbMovie omdbmovie)
        {
            return _movieprocessor.CreateMovie(omdbmovie);
        }
        #endregion

        #region ActorTags
        public ActorTag GetActorTagById(int id)
        {
            return _actortagprocessor.GetById(id);
        }

        public List<ActorTag> GetAllActorTags()
        {
            return _actortagprocessor.GetAllTags();
        }

        public ActorTag CreateActorTag(ActorTag actortag, int actorid)
        {
            return _actortagprocessor.CreateTag(actortag, actorid);
        }

        public ActorTag UpdateActorTag(ActorTag actortag)
        {
            return _actortagprocessor.UpdateTag(actortag);
        }

        public void DeleteActorTagRelationship(ActorTag actortag, int actorid)
        {
            _actortagprocessor.DeleteTagRelationship(actortag, actorid);
        }
        #endregion

        #region MovieTags
        public MovieTag GetMovieTagById(int id)
        {
            return _movietagprocessor.GetById(id);
        }

        public List<MovieTag> GetAllMovieTags()
        {
            return _movietagprocessor.GetAllTags();
        }

        public MovieTag CreateMovieTag(MovieTag movietag, string movieid)
        {
            return _movietagprocessor.CreateTag(movietag, movieid);
        }

        public List<MovieTag> GetByMovie(string id)
        {
            return _movietagprocessor.GetByMovie(id);
        }

        public MovieTag UpdateMovieTag(MovieTag movietag)
        {
            return _movietagprocessor.UpdateTag(movietag);
        }

        public void DeleteMovieTagRelationship(MovieTag movietag, string movieid)
        {
            _movietagprocessor.DeleteTagRelationship(movietag, movieid);
        }


        #endregion
    }
}
