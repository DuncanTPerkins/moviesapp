using MoviesApp.Models;
using System.Collections.Generic;

namespace MoviesApp.BizTier
{
    public interface IActorProcessor : IBaseProcessor
    {
        Actor GetById(int id);
        List<Actor> GetAllActors();
        Actor GetByName(string name);
        Actor CreateActor(Actor actor);
        List<Actor> GetActorsByString(string actorstring);
    }
}
