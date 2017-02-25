using System.Collections.Generic;
using MoviesApp.Models;

namespace MoviesApp.BizTier.Bridge
{
    public interface IActorTagConnector
    {
        ActorTag GetById(int id);
        List<ActorTag> GetAllTags();
        ActorTag CreateTag(ActorTag actortag, int actorid);
        ActorTag UpdateTag(ActorTag actortag);
        void DeleteTagRelationship(ActorTag actortag, int actorid);
    }
}