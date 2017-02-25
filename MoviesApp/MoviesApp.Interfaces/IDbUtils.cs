using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public interface DbUtils
    {
        Movie GetMovie(SqlDataReader dr);
        void InsertMovie(SqlConnection conn, Movie movie);
        Actor GetActor(SqlDataReader dr);
        SqlCommand InsertActor(SqlConnection conn, Actor actor);
        SqlCommand InsertMovieTag(SqlConnection conn, ITag movietag);
        SqlCommand InsertActorTag(SqlConnection conn, ITag actortag);
        void InsertActorMovieRelationship(SqlConnection conn, Movie movie, Actor actor);
        void InsertMovieMovieTagRelationship(SqlConnection conn, Movie movie, ITag movietag);
        void InsertActorActorTagRelationship(SqlConnection conn, Actor actor, ITag actortag);
        ITag GetMovieTag(SqlDataReader dr);
        ITag GetActorTag(SqlDataReader dr);
        void FillActorsandMovieTags(SqlDataReader dr, Movie movie);
        void FillMoviesandActorTags(SqlDataReader dr, Actor actor);
    }
}
