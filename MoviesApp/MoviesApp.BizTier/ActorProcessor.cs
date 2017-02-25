using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MoviesApp.BizTier.Bridge;

namespace MoviesApp.BizTier
{
    public class ActorProcessor : IActorProcessor
    {
        private IActorConnector _connector;
        public ActorProcessor(IActorConnector actorcoupler)
        {
            _connector = actorcoupler;
        }
        public Actor GetById(int id)
        {
            return _connector.GetById(id);
        }

        public List<Actor> GetAllActors()
        {
            return _connector.GetAllActors().ToList();
        }

        public Actor GetByName(string name)
        {
            return _connector.GetByName(name);
        }

        public Actor CreateActor(Actor actor)
        {
            return _connector.CreateActor(actor);
        }

        public List<Actor> GetActorsByString(string actorstring)
        {
            const char DELIMITER = ',';
            if (actorstring.IndexOf(DELIMITER) == -1)
            {
                throw new ArgumentException(string.Format("Delimiter in Actor String must be \"{0}\"", DELIMITER));
            }
            else
            {
                var actorstrings = actorstring.Split(DELIMITER).ToList();
                var actors = new List<Actor>();
                foreach (var actor in actorstrings)
                {
                    var returnedactor = this.GetByName(actor.Trim());
                    if (string.IsNullOrEmpty(returnedactor.Name))
                    {
                        actors.Add(new Actor()
                        {
                            Name = actor.Trim()
                        });
                    }
                    else
                    {
                        actors.Add(returnedactor);
                    }
                }
                return actors;
            }
        }
    }
}
