using System.Web.Http;
using MoviesApp.AppTier.Bridge;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    [RoutePrefix("api/actors")]
    public class ActorController : ApiController, IActorController
    {
        private IActorCoupler _coupler;

        public ActorController(IActorCoupler coupler)
        {
            _coupler = coupler;
        }
        #region Gets
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_coupler.GetById(id));
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_coupler.GetAllActors());
        }

        [Route("name/{name}")]
        public IHttpActionResult Get(string name)
        {
            return Ok(_coupler.GetByName(name));
        }
        #endregion

        #region Sets
        [Route("")]
        public IHttpActionResult Post(Actor actor)
        {
            return Created("path", _coupler.CreateActor(actor));
        }
        #endregion
    }
}
