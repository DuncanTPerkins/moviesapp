using MoviesApp.Models;
using System.Collections.Generic;
namespace MoviesApp.AppTier.Bridge
{
    public interface IActorCoupler
    {
        Actor GetById(int id);
        IEnumerable<Actor> GetAllActors();
        Actor GetByName(string name);
        Actor CreateActor(Actor actor);
    }
}
