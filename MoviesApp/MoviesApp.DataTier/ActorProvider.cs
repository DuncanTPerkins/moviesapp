using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MoviesApp.DataTier
{
    public class ActorProvider : BaseProvider, IActorProvider
    {
        private SqlConnection conn;
        public ActorProvider()
        {
            conn = new SqlConnection(ConnectionString);
        }
        public Actor GetById(int id)
        {
            var actor = new Actor();
            using (conn)
            {
                var sp = "dbo.usp_GetActorById";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                            actor = _utils.GetActor(dr);

                            _utils.FillMoviesandActorTags(dr, actor);
                    }
                }
            }
            return actor;
        }

        public List<Actor> GetAllActors()
        {
            List<Actor> actors = new List<Actor>();
            Actor currentactor = new Actor();
            using (conn)
            {
                var sp = "dbo.usp_GetAllActors";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (Convert.ToInt32(dr["ActorID"]) == currentactor.ActorId)
                        {
                            _utils.FillMoviesandActorTags(dr, currentactor);
                        }
                        else
                        {
                            if (currentactor.ActorId != 0)
                            {
                                actors.Add(currentactor);
                            }

                            currentactor = _utils.GetActor(dr);

                            _utils.FillMoviesandActorTags(dr, currentactor);
                        }
                    }
                    actors.Add(currentactor);
                }
            }
            return actors;
        }

        public Actor GetByName(string name)
        {
            var actor = new Actor();
            using (conn)
            {
                var sp = "dbo.usp_GetActorByName";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@name", name);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (actor.ActorId != 0)
                        {
                            _utils.FillMoviesandActorTags(dr, actor);
                        }
                        else
                        {
                            actor = _utils.GetActor(dr);
                            _utils.FillMoviesandActorTags(dr, actor);
                        }
                    }
                }
            }
            return actor;
        }

        public Actor CreateActor(Actor actor)
        {
            using (conn)
            {
                SqlCommand cmd = _utils.InsertActor(conn, actor);
                try
                {
                    conn.Open();
                    actor.ActorId = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                foreach (var movie in actor.Movies)
                {
                    cmd.CommandText = "dbo.usp_GetMovieById";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@Id", movie.ImdbId);
                    var foundmovie = new Movie();
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            foundmovie = _utils.GetMovie(dr);
                        }
                    }

                    cmd.CommandText = "dbo.usp_GetActorMovieRelationship";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@ActorID", actor.ActorId);
                    cmd.Parameters.AddWithValue("@MovieID", movie.ImdbId);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dr["ActorID"] == DBNull.Value)
                            {
                                //if relationship didn't exist yet
                                cmd.CommandText = "dbo.usp_InsActorMovieRelationship";
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@MovieID", movie.ImdbId);
                                cmd.Parameters.AddWithValue("@ActorID", actor.ActorId);
                                _utils.NonQuery(cmd, conn);
                            }
                        }
                    }
                }
                return actor;
            }
        }
    }
}
