using MoviesApp.Models;
using System.Web.Http;

namespace MoviesApp.Controllers
{
    public interface IActorTagController
    {
        IHttpActionResult Get(int id);

        IHttpActionResult Get();

        IHttpActionResult Post([FromBody] ActorTag tag, [FromUri] int actorid = 0);

        IHttpActionResult Put(ActorTag tag);

        IHttpActionResult Delete(ActorTag tag, int actorid);
    }
}