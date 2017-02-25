using MoviesApp.Models;
using System.Collections.Generic;
using MoviesApp.BizTier.Bridge;

namespace MoviesApp.BizTier
{
    public class ActorTagProcessor: IActorTagProcessor
    {
        private IActorTagConnector _actortagconnector;

        public ActorTagProcessor(IActorTagConnector actortagprovider)
        {
            _actortagconnector = actortagprovider;
        }

        public ActorTag GetById(int id)
        {
            return _actortagconnector.GetById(id);
        }

        public List<ActorTag> GetAllTags()
        {
            return _actortagconnector.GetAllTags();
        }

        public ActorTag CreateTag(ActorTag actortag, int actorid)
        {
            return _actortagconnector.CreateTag(actortag, actorid);
        }

        public ActorTag UpdateTag(ActorTag actortag)
        {
            return _actortagconnector.UpdateTag(actortag);
        }

        public void DeleteTagRelationship(ActorTag actortag, int actorid)
        {
            _actortagconnector.DeleteTagRelationship(actortag, actorid);
        }
    }
}
