using MoviesApp.Models;
using System.Web.Http;

namespace MoviesApp.Controllers
{
    public interface IMovieTagController
    {
        IHttpActionResult Get(int id);
        IHttpActionResult GetByMovie(string id);
        IHttpActionResult Get();
        IHttpActionResult Post([FromBody] MovieTag movietag, [FromUri] string movieid = "");
        IHttpActionResult Put(MovieTag tag);
        IHttpActionResult Delete(MovieTag tag, string movieid);
    }
}