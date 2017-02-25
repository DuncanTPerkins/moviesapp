using MoviesApp.Models;
using System.Collections.Generic;
using MoviesApp.BizTier.Bridge.DataService;
using System;

namespace MoviesApp.BizTier.Bridge
{
    public class ActorConnector: IActorConnector
    {
        private IDataService _dataservice;
        public ActorConnector(IDataService dataservice)
        {
            _dataservice = dataservice;
        }

        public Actor GetById(int id)
        {
            return _dataservice.GetActorById(id);
        }

        public IEnumerable<Actor> GetAllActors()
        {
            return _dataservice.GetAllActors();
        }

        public Actor GetByName(string name)
        {
            return _dataservice.GetByName(name);
        }

        public Actor CreateActor(Actor actor)
        {
            return _dataservice.CreateActor(actor);
        }
    }
}
