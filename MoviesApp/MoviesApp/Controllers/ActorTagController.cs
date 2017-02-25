using MoviesApp.BizTier;
using MoviesApp.Models;
using System.Web.Http;
using MoviesApp.AppTier.Bridge;

namespace MoviesApp.Controllers
{
    [RoutePrefix("api/actortags")]
    public class ActorTagController : ApiController, IActorTagController
    {
        private IActorTagCoupler _actortagcoupler;
        public ActorTagController(IActorTagCoupler actortagcoupler)
        {
            _actortagcoupler = actortagcoupler;
        }

        #region Gets
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_actortagcoupler.GetById(id));
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_actortagcoupler.GetAllTags());
        }
        #endregion

        #region Sets
        [Route("{actorid}")]
        public IHttpActionResult Post([FromBody] ActorTag tag, [FromUri] int actorid = 0)
        {
            return Created("path", _actortagcoupler.CreateTag(tag, actorid));
        }

        public IHttpActionResult Put(ActorTag tag)
        {
            return Created("path", _actortagcoupler.UpdateTag(tag));
        }

        public IHttpActionResult Delete([FromBody] ActorTag tag, [FromUri] int actorid)
        {
            _actortagcoupler.DeleteTagRelationship(tag, actorid);
            return Ok();
        }
        #endregion
    }
}