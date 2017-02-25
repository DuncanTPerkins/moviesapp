using MoviesApp.BizTier;
using MoviesApp.Models;
using System.Web.Http;
using MoviesApp.AppTier.Bridge;

namespace MoviesApp.Controllers
{
    [RoutePrefix("api/movietags")]
    public class MovieTagController : ApiController, IMovieTagController
    {
        private readonly IMovieTagCoupler _movietagcoupler;

        public MovieTagController(IMovieTagCoupler movietagcoupler)
        {
            _movietagcoupler = movietagcoupler;
        }
        #region Gets
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(_movietagcoupler.GetById(id));
        }

        [Route("bymovie/{id}")]
        public IHttpActionResult GetByMovie(string id)
        {
            return Ok(_movietagcoupler.GetByMovie(id));
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_movietagcoupler.GetAllTags());
        }
        #endregion

        #region Sets
        [HttpPost]
        [Route("{movieid}")]
        public IHttpActionResult Post([FromBody] MovieTag movietag, [FromUri] string movieid = "")
        {
            return Created("path", _movietagcoupler.CreateTag(movietag, movieid));
        }

        [Route("")]
        public IHttpActionResult Put(MovieTag tag)
        {
            return Created("path", _movietagcoupler.UpdateTag(tag));
        }

        [Route("removerelationship/{movieid}")]
        [HttpPost]
        public IHttpActionResult Delete([FromBody]MovieTag tag, [FromUri] string movieid = "")
        {
            _movietagcoupler.DeleteTagRelationship(tag, movieid);
            return Ok();
        }
        #endregion
    }
}