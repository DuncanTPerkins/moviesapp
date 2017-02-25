using MoviesApp.Models;
using System.Collections.Generic;

namespace MoviesApp.DataTier
{
    public interface IActorProvider : IBaseProvider
    {
        Actor GetById(int id);
        List<Actor> GetAllActors();
        Actor GetByName(string name);
        Actor CreateActor(Actor actor);
    }
}
