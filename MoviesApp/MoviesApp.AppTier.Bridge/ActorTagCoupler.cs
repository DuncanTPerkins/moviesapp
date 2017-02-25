using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesApp.AppTier.Bridge.BizService;
using MoviesApp.Models;

namespace MoviesApp.AppTier.Bridge
{
    public class ActorTagCoupler : IActorTagCoupler
    {
        private IBizService _bizservice;

        public ActorTagCoupler(IBizService bizservice)
        {
            _bizservice = bizservice;
        }
        public ActorTag CreateTag(ActorTag actortag, int actorid)
        {
            return _bizservice.CreateActorTag(actortag, actorid);
        }

        public void DeleteTagRelationship(ActorTag actortag, int actorid)
        {
            _bizservice.DeleteActorTagRelationship(actortag, actorid);
        }

        public List<ActorTag> GetAllTags()
        {
            return _bizservice.GetAllActorTags();
        }

        public ActorTag GetById(int id)
        {
            return _bizservice.GetActorTagById(id);
        }

        public ActorTag UpdateTag(ActorTag actortag)
        {
            return _bizservice.UpdateActorTag(actortag);
        }
    }
}

