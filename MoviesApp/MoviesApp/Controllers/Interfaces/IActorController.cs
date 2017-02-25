using MoviesApp.Models;
using System.Web.Http;
namespace MoviesApp.Controllers
{
    public interface IActorController
    {
        IHttpActionResult Get(int id);
        IHttpActionResult Get();
        IHttpActionResult Get(string name);
        IHttpActionResult Post(Actor actor);
    }
}
