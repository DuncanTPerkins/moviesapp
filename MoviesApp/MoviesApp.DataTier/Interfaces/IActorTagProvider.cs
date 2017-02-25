using MoviesApp.Models;
using System.Collections.Generic;

namespace MoviesApp.DataTier
{
    public interface IActorTagProvider: IBaseProvider
    {
        ActorTag GetById(int id);

        List<ActorTag> GetAllTags();

        ActorTag CreateTag(ActorTag actortag, int actorid);

        ActorTag UpdateTag(ActorTag actortag);

        void DeleteTagRelationship(ActorTag actortag, int actorid);
    }
}
