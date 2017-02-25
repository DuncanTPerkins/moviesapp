using MoviesApp.Models;
using System.Collections.Generic;

namespace MoviesApp.BizTier.Bridge
{
    public interface IActorConnector
    {
        Actor GetById(int id);
        IEnumerable<Actor> GetAllActors();
        Actor GetByName(string name);
        Actor CreateActor(Actor actor);
    }
}
