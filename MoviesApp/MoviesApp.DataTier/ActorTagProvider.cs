using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoviesApp.DataTier
{
    public class ActorTagProvider : BaseProvider, IActorTagProvider
    {
        private SqlConnection conn;
        public ActorTagProvider(): base()
        {
            conn = new SqlConnection(this.ConnectionString);
        }
        public ActorTag GetById(int id)
        {
            Actor actor = new Actor();
            using (conn)
            {
                var sp = "dbo.usp_GetActorTagById";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        return _utils.GetActorTag(dr);
                    }
                    throw new Exception();
                }
            }
        }

        public List<ActorTag> GetAllTags()
        {
            List<ActorTag> tags = new List<ActorTag>();
            using (conn)
            {
                var sp = "dbo.usp_GetAllActorTags";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        tags.Add(_utils.GetActorTag(dr));
                    }
                    return tags;
                }
            }
        }

        public ActorTag CreateTag(ActorTag actortag, int actorid)
        {
            using (conn)
            {
                var sp = "dbo.usp_GetActorTagByName";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@TagDescription", actortag.TagDescription);
                _utils.NonQuery(cmd, conn);
                conn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    //tag exists already
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            actortag.TagId = Convert.ToInt32(dr["ActorTagId"]);
                        }
                    }
                    else
                    {
                        conn.Close(); //close dr connection so that a new one can be created
                        sp = "dbo.usp_InsActorTag";
                        cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                        cmd.Parameters.AddWithValue("@TagDescription", actortag.TagDescription);
                        actortag.TagId = _utils.Scalar(cmd, conn);
                    }
                }


                //if there's an actor
                if (actorid != 0)
                {
                    sp = "dbo.usp_InsActorActorTagRelationships";
                    cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@ActorId", actorid);
                    cmd.Parameters.AddWithValue("@ActorTagId", actortag.TagId);
                    _utils.NonQuery(cmd, conn);
                }
            }
            return actortag;
        }

        public ActorTag UpdateTag(ActorTag actortag)
        {
            using (conn)
            {
                var sp = "dbo.usp_UpdActorTag";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@ActorTagID", actortag.TagId);
                cmd.Parameters.AddWithValue("@TagDescription", actortag.TagDescription);
                _utils.NonQuery(cmd, conn);
            }
            return actortag;
        }

        public void DeleteTagRelationship(ActorTag actortag, int actorid)
        {
            using (conn)
            {
                var sp = "dbo.usp_DelActorActorTagRelationship";
                var cmd = new SqlCommand(sp, conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@ActorTagID", actortag.TagId);
                cmd.Parameters.AddWithValue("@ActorID", actorid);
                _utils.NonQuery(cmd, conn);
            }
        }
    }
}
