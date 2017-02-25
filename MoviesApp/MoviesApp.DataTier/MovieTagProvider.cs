using MoviesApp.DataTier;
using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MoviesApp.BizTier
{
    public class MovieTagProvider: BaseProvider, IMovieTagProvider
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MovieDb"].ConnectionString);
        public MovieTag GetById(int id)
        {
            using (conn)
            {
                var sp = "dbo.usp_GetMovieTagById";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        return _utils.GetMovieTag(dr);
                    }
                    throw new Exception();
                }
            }
        }

        public List<MovieTag> GetByMovie(string id)
        {
            var tags = new List<MovieTag>();
            var sp = "usp_GetMovieTagsByMovie";
            var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.AddWithValue("@MovieId", id);
            conn.Open();
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    tags.Add(_utils.GetMovieTag(dr));
                }
            }
            return tags;
        }

        public List<MovieTag> GetAllTags()
        {
            List<MovieTag> tags = new List<MovieTag>();
            using (conn)
            {
                var sp = "dbo.usp_GetAllMovieTags";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        tags.Add(_utils.GetMovieTag(dr));
                    }
                    return tags;
                }
            }
        }

        public MovieTag CreateTag(MovieTag movietag, string movieid)
        {
            using (conn)
            {
                var sp = "dbo.usp_GetMovieTagByName";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@TagDescription", movietag.TagDescription);
                _utils.NonQuery(cmd, conn);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    //tag exists already
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            movietag.TagId = Convert.ToInt32(dr["MovieTagId"]);
                        }
                    }
                    else
                    {
                        conn.Close();
                        sp = "dbo.usp_InsMovieTag";
                        cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                        cmd.Parameters.AddWithValue("@TagDescription", movietag.TagDescription);
                        movietag.TagId = _utils.Scalar(cmd, conn);
                    }
                }


                //if there's an actor
                if (!String.IsNullOrEmpty(movieid))
                {
                    sp = "dbo.usp_InsMovieMovieTagRelationships";
                    cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@MovieId", movieid);
                    cmd.Parameters.AddWithValue("@MovieTagId", movietag.TagId);
                    _utils.NonQuery(cmd, conn);
                }
            }
            return movietag;
        }

        public MovieTag UpdateTag(MovieTag movietag)
        {
            using (conn)
            {
                var sp = "dbo.usp_UpdMovieTag";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@MovieTagID", movietag.TagId);
                cmd.Parameters.AddWithValue("@TagDescription", movietag.TagDescription);
                _utils.NonQuery(cmd, conn);
            }
            return movietag;
        }

        public void DeleteTagRelationship(MovieTag movietag, String movieid)
        {
            using (conn)
            {
                var sp = "dbo.usp_DelMovieMovieTagRelationships";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@MovieTagID", movietag.TagId);
                cmd.Parameters.AddWithValue("@MovieId", movieid);
                _utils.NonQuery(cmd, conn);
            }
        }
    }
}
