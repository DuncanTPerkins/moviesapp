using MoviesApp.Models;
using System.Collections.Generic;
using MoviesApp.BizTier.Bridge.DataService;

namespace MoviesApp.BizTier.Bridge
{
    public class ActorTagConnector: IActorTagConnector
    {
        private IDataService _dataservice;

        public ActorTagConnector(IDataService dataservice)
        {
            _dataservice = dataservice;
        }

        public ActorTag GetById(int id)
        {
            return _dataservice.GetActorTagById(id);
        }

        public List<ActorTag> GetAllTags()
        {
            return _dataservice.GetAllActorTags();
        }

        public ActorTag CreateTag(ActorTag actortag, int actorid)
        {
            return _dataservice.CreateActorTag(actortag, actorid);
        }

        public ActorTag UpdateTag(ActorTag actortag)
        {
            return _dataservice.UpdateActorTag(actortag);
        }

        public void DeleteTagRelationship(ActorTag actortag, int actorid)
        {
            _dataservice.DeleteActorTag(actortag);
        }
    }
}
