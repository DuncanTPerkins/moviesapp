using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MoviesApp.Models;

namespace MoviesApp.DataTier.Facade
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDataService" in both code and config file together.
    [ServiceContract]
    interface IDataService
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
        #endregion

        #region Movie
        [OperationContract]
        Movie GetMovieById(string id);

        [OperationContract]
        List<Movie> GetAllMovies();

        [OperationContract]
        Movie GetByTitle(string title);

        [OperationContract]
        Movie CreateMovie(Movie movie);
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
        void DeleteMovieTagRelationship(MovieTag movietag, String movieid);
        #endregion
    }
}
