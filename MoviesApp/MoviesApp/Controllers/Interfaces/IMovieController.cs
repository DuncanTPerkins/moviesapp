using MoviesApp.Models;
using System.Web.Http;

namespace MoviesApp.Controllers
{
    public interface IMovieController
    {
        IHttpActionResult GetById(string id);
        IHttpActionResult Get();
        IHttpActionResult Get(string title);
        IHttpActionResult Post(OmdbMovie omdbmovie);
    }
}