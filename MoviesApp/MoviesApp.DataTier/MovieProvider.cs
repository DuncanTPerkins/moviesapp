using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesApp.DataTier
{
    public class MovieProvider : BaseProvider, IMovieProvider
    {
        private SqlConnection conn;
        public MovieProvider()
        {
            conn = new SqlConnection(this.ConnectionString);
        }
        public Movie GetById(string id)
        {
            Movie movie = new Movie();
            using (conn)
            {
                var sp = "dbo.usp_GetMoviesById";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (!String.IsNullOrEmpty(movie.ImdbId))
                        {
                            _utils.FillActorsandMovieTags(dr, movie);
                        }
                        else
                        {
                            movie = _utils.GetMovie(dr);
                            _utils.FillActorsandMovieTags(dr, movie);
                        }
                    }
                }
            }
            return movie;
        }

        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            Movie currentmovie = new Movie();
            using (conn)
            {
                var sp = "dbo.usp_GetAllMovies";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (Convert.ToString(dr["MovieID"]) == currentmovie.ImdbId)
                        {
                            _utils.FillActorsandMovieTags(dr, currentmovie);
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(currentmovie.ImdbId))
                            {
                                movies.Add(currentmovie);
                            }

                            currentmovie = _utils.GetMovie(dr);

                            _utils.FillActorsandMovieTags(dr, currentmovie);
                        }
                    }
                    movies.Add(currentmovie);
                }
            }
            return movies;
        }

        public Movie GetByTitle(string title)
        {
            Movie movie = new Movie();
            using (conn)
            {
                var sp = "dbo.usp_GetMovieByTitle";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@title", title);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        movie = _utils.GetMovie(dr);
                        _utils.FillActorsandMovieTags(dr, movie);
                    }
                }
            }
            return movie;
        } 

        public Movie CreateMovie(Movie movie)
        {
            using (conn)
            {
                SqlCommand cmd = conn.CreateCommand();
                _utils.InsertMovie(conn, movie);
                foreach (var actor in movie.Actors)
                {
                    var sp = "dbo.usp_GetActorByName";
                    cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@Name", actor.Name);
                    conn.Open();
                    Actor foundactor = new Actor();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            foundactor = _utils.GetActor(dr);
                        }
                    }
                    conn.Close();
                    //if actor exist already
                    if (foundactor.ActorId != 0)
                    {
                        _utils.InsertActorMovieRelationship(conn, movie, foundactor);
                    }

                    //if actor didn't exist
                    else
                    {
                        cmd = _utils.InsertActor(conn, actor);
                        actor.ActorId = _utils.Scalar(cmd, conn);
                        _utils.InsertActorMovieRelationship(conn, movie, actor);
                    }
                }

                foreach(var movietag in movie.MovieTags)
                {
                    var sp = "dbo.usp_GetMovieTagsByMovie";
                    cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@ImdbId", movie.ImdbId);
                    conn.Open();
                    MovieTag foundtag = new MovieTag();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            foundtag = _utils.GetMovieTag(dr);
                        }
                    }
                    conn.Close();
                    //if actor exists already
                    if (movietag != null)
                    {
                        _utils.InsertMovieMovieTagRelationship(conn, movie, foundtag);
                    }

                    //if actor didn't exist
                    else
                    {
                        cmd = _utils.InsertMovieTag(conn, movietag);
                        try
                        {
                            conn.ConnectionString = ConnectionString;
                            conn.Open();
                            movietag.TagId = (int)cmd.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            conn.Close();
                        }
                        _utils.InsertMovieMovieTagRelationship(conn, movie, movietag);
                    }
                }
                return movie;
            }
        }
    }
}
