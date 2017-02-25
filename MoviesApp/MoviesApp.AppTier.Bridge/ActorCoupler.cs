using System.Collections.Generic;
using MoviesApp.Models;
using MoviesApp.AppTier.Bridge.BizService;

namespace MoviesApp.AppTier.Bridge
{
    public class ActorCoupler: IActorCoupler
    {
        private IBizService _bizservice;
        public ActorCoupler(IBizService bizservice)
        {
            _bizservice = bizservice;
        }

        public Actor GetById(int id)
        {
            return _bizservice.GetActorById(id);
        }

        public IEnumerable<Actor> GetAllActors()
        {
            return _bizservice.GetAllActors();
        }

        public Actor GetByName(string name)
        {
            return _bizservice.GetByName(name);
        }

        public Actor CreateActor(Actor actor)
        {
            return _bizservice.CreateActor(actor);
        }
    }
}
