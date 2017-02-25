using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace MoviesApp.Models
{
    public class DbUtils
    {
        public Movie GetMovie(SqlDataReader dr)
        {
            Movie movie = null;
            if(dr["MovieID"] != DBNull.Value)
            {
                movie = new Movie()
                {
                    ImdbId = Convert.ToString(dr["MovieID"]),
                    Title = Convert.ToString(dr["Title"]),
                    Year = dr["Year"] == DBNull.Value ? new DateTime?() : Convert.ToDateTime(dr["Year"]),
                    Rated = Convert.ToString(dr["Rated"]),
                    Released = dr["Released"] == DBNull.Value ? new DateTime?() : Convert.ToDateTime(dr["Released"]),
                    Genre = Convert.ToString(dr["Genre"]),
                    Director = Convert.ToString(dr["Director"]),
                    Writer = Convert.ToString(dr["Writer"]),
                    Plot = Convert.ToString(dr["Plot"]),
                    Language = Convert.ToString(dr["Language"]),
                    Favorited = Convert.ToInt32(dr["Favorited"]),
                    Watched = Convert.ToInt32(dr["Watched"]),
                    Country = Convert.ToString(dr["Country"]),
                    Awards = Convert.ToString(dr["Awards"]),
                    Poster = Convert.ToString(dr["Poster"]),
                    Metascore = Convert.ToInt32(dr["Metascore"]),
                    ImdbRating = Convert.ToString(dr["ImdbRating"]),
                    ImdbVotes = Convert.ToString(dr["ImdbVotes"]),
                    Type = Convert.ToString(dr["Type"]),
                    Response = Convert.ToString(dr["Response"])
                };
            }
            return movie;
        }

        public void InsertMovie(SqlConnection conn, Movie movie)
        {
            SqlCommand cmd = conn.CreateCommand();
            //cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.usp_InsMovie";
            cmd.Parameters.AddWithValue("@MovieID", movie.ImdbId);
            cmd.Parameters.AddWithValue("@Title", movie.Title);
            cmd.Parameters.AddWithValue("@Year", movie.Year);
            cmd.Parameters.AddWithValue("@Rated", movie.Rated);
            cmd.Parameters.AddWithValue("@Released", movie.Released);
            cmd.Parameters.AddWithValue("@Genre", movie.Genre);
            cmd.Parameters.AddWithValue("@Director", movie.Director);
            cmd.Parameters.AddWithValue("@Writer", movie.Writer);
            cmd.Parameters.AddWithValue("@Plot", movie.Plot);
            cmd.Parameters.AddWithValue("@Language", movie.Language);
            cmd.Parameters.AddWithValue("@Country", movie.Country);
            cmd.Parameters.AddWithValue("@Awards", movie.Awards);
            cmd.Parameters.AddWithValue("@Poster", movie.Poster);
            cmd.Parameters.AddWithValue("@Metascore", movie.Metascore);
            cmd.Parameters.AddWithValue("@Favorited", movie.Favorited);
            cmd.Parameters.AddWithValue("@Watched", movie.Watched);
            cmd.Parameters.AddWithValue("@ImdbRating", movie.ImdbRating);
            cmd.Parameters.AddWithValue("@ImdbVotes", movie.ImdbVotes);
            cmd.Parameters.AddWithValue("@Type", movie.Type);
            cmd.Parameters.AddWithValue("@Response", movie.Response);
            this.NonQuery(cmd, conn);
        }

        public Actor GetActor(SqlDataReader dr)
        {
            Actor actor = null;
            if (dr["ActorID"] != DBNull.Value)
            {
                actor = new Actor()
                {
                    ActorId = Convert.ToInt32(dr["ActorID"]),
                    Name = Convert.ToString(dr["Name"]),
                };
            }
            return actor;
        }

        public SqlCommand InsertActor(SqlConnection conn, Actor actor)
        {
            SqlCommand cmd = conn.CreateCommand();
            var sp = "dbo.usp_InsActor";
            cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Name", actor.Name);
            cmd.Parameters.AddWithValue("@Favorited", actor.Favorited);
            return cmd;
        }
        public SqlCommand InsertMovieTag(SqlConnection conn, MovieTag movietag)
        {
            SqlCommand cmd = conn.CreateCommand();
            var sp = "dbo.usp_InsMovieTag";
            cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@MovieTagId", movietag.TagId);
            cmd.Parameters.AddWithValue("@TagDescription", movietag.TagDescription);
            return cmd;
        }
        public SqlCommand InsertActorTag(SqlConnection conn, ActorTag actortag)
        {
            SqlCommand cmd = conn.CreateCommand();
            var sp = "dbo.usp_InsMovieTag";
            cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ActorTagId", actortag.TagId);
            cmd.Parameters.AddWithValue("@TagDescription", actortag.TagDescription);
            return cmd;
        }
        public void InsertActorMovieRelationship(SqlConnection conn, Movie movie, Actor actor)
        {
            SqlCommand cmd;
            var sp = "dbo.usp_InsActorMovieRelationship";
            cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@MovieId", movie.ImdbId);
            cmd.Parameters.AddWithValue("@ActorId", actor.ActorId);
            this.NonQuery(cmd, conn);
        }
        public void InsertMovieMovieTagRelationship(SqlConnection conn, Movie movie, MovieTag movietag)
        {
            SqlCommand cmd;
            var sp = "dbo.usp_InsMovieMovieTagRelationship";
            cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@MovieId", movie.ImdbId);
            cmd.Parameters.AddWithValue("@MovieTagId", movietag.TagId);
            this.NonQuery(cmd, conn);
        }
        public void InsertActorActorTagRelationship(SqlConnection conn, Actor actor, ActorTag actortag)
        {
            SqlCommand cmd;
            var sp = "dbo.usp_InsActorActorTagRelationship";
            cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@ActorId", actor.ActorId);
            cmd.Parameters.AddWithValue("@ActorTagId", actortag.TagId);
            this.NonQuery(cmd, conn);
        }

        public MovieTag GetMovieTag(SqlDataReader dr)
        {
            MovieTag movietag = null;
            if (dr["MovieTagId"] != DBNull.Value)
            {
                movietag = new MovieTag()
                {
                    TagId = dr["MovieTagId"] == DBNull.Value ? 0 : Convert.ToInt32(dr["MovieTagId"]),
                    TagDescription = Convert.ToString(dr["TagDescription"])
                };
            }
            return movietag;
        }

        public ActorTag GetActorTag(SqlDataReader dr)
        {
            ActorTag actortag = null;
            if(dr["ActorTagId"] != DBNull.Value)
            {
                actortag = new ActorTag()
                {
                    TagId = Convert.ToInt32(dr["ActorTagId"]),
                    TagDescription = Convert.ToString(dr["TagDescription"])
                };
            }
            return actortag;
        }

        public void FillActorsandMovieTags(SqlDataReader dr, Movie movie)
        {
            var actor = this.GetActor(dr);
            var movietag = this.GetMovieTag(dr);
            var actorlist = movie.Actors.Where(x => x.ActorId == actor.ActorId);
            var movietaglist = movie.MovieTags.Where(x => x.TagId == movietag.TagId);
            if (actor != null && actorlist.Count() < 1)
            {
                movie.Actors.Add(actor);
            }

            if (movietag != null && movietaglist.Count() < 1)
            {
                movie.MovieTags.Add(movietag);
            }
        }
        public void FillMoviesandActorTags(SqlDataReader dr, Actor actor)
        {
            var movie = this.GetMovie(dr);
            var actortag = this.GetActorTag(dr);
            var movielist = actor.Movies.Where(x => x.ImdbId == movie.ImdbId);
            var movietaglist = actor.ActorTags.Where(x => x.TagId == actortag.TagId);
            if (movie != null && movielist.Count() < 1)
            {
                actor.Movies.Add(movie);
            }

            if (actortag != null && movietaglist.Count() < 1)
            {
                actor.ActorTags.Add(actortag);
            }
        }


        public void NonQuery(SqlCommand cmd, SqlConnection conn)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public int Scalar(SqlCommand cmd, SqlConnection conn)
        {
            int id;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                id = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return id;
        }
    }
}
