using MoviesApp.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceModel;

namespace MoviesApp.BizTier.Facade
{
    [ServiceContract]
    interface IBizService
    {
        #region Actor
        [OperationContract]
        Actor GetActorById(int id);

        [OperationContract]
        List<Actor> GetAllActors();

        [OperationContract]
        Actor GetByName(string name);

        [OperationContract]
        Actor CreateActor(Actor actor);

        [OperationContract]
        List<Actor> GetActorsByString(string actorstring);
        #endregion

        #region Movie
        [OperationContract]
        Movie GetMovieById(string id);

        [OperationContract]
        List<Movie> GetAllMovies();

        [OperationContract]
        Movie GetByTitle(string title);

        [OperationContract]
        Movie CreateMovie(OmdbMovie omdbmovie);
        #endregion

        #region ActorTag
        [OperationContract]
        ActorTag GetActorTagById(int id);

        [OperationContract]
        List<ActorTag> GetAllActorTags();

        [OperationContract]
        ActorTag CreateActorTag(ActorTag actortag, int actorid);

        [OperationContract]
        ActorTag UpdateActorTag(ActorTag actortag);

        [OperationContract]
        void DeleteActorTagRelationship(ActorTag actortag, int actorid);
        #endregion

        #region MovieTag
        [OperationContract]
        MovieTag GetMovieTagById(int id);

        [OperationContract]
        List<MovieTag> GetByMovie(string id);

        [OperationContract]
        List<MovieTag> GetAllMovieTags();

        [OperationContract]
        MovieTag CreateMovieTag(MovieTag movietag, string movieid);

        [OperationContract]
        MovieTag UpdateMovieTag(MovieTag movietag);

        [OperationContract]
        void DeleteMovieTagRelationship(MovieTag movietag, string movieid);
        #endregion
    }
}
