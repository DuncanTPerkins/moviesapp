using MoviesApp.BizTier;
using MoviesApp.Models;
using System;
using System.Web.Http;
using MoviesApp.AppTier.Bridge;

namespace MoviesApp.Controllers
{

    [RoutePrefix("api/movies")]
    public class MovieController : ApiController, IMovieController
    {
        private IMovieCoupler _moviecoupler;

        public MovieController(IMovieCoupler moviecoupler)
        {
            _moviecoupler = moviecoupler;
        }
        #region Gets

        //done
        [Route("{id}")]
        public IHttpActionResult GetById(string id)
        {
            return Ok(_moviecoupler.GetById(id));
        }
        
        //done
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(_moviecoupler.GetAllMovies());
        }

        //Find by title
        [Route("title/{title}")]
        public IHttpActionResult Get(string title)
        {
            return Ok(_moviecoupler.GetByTitle(title));
        }
        #endregion

        //done
        #region Sets
        [Route("")]
        public IHttpActionResult Post(OmdbMovie omdbmovie)
        {
            try
            {
                return Created("path", _moviecoupler.CreateMovie(omdbmovie));
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}