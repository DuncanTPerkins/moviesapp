using MoviesApp.DataTier;
using MoviesApp.Models;
using System;
using System.Collections.Generic;
using MoviesApp.BizTier.Bridge;

namespace MoviesApp.BizTier
{
    public class MovieProcessor: IMovieProcessor
    {
        private IMovieConnector _movieconnector;
        private IActorProcessor _actorprocessor;
        public MovieProcessor(IMovieConnector movieconnector, IActorProcessor actorprocessor)
        {
            _movieconnector = movieconnector;
            _actorprocessor = actorprocessor;
        }
        public Movie GetById(string id)
        {
            return _movieconnector.GetById(id);
        }

        public List<Movie> GetAllMovies()
        {
            return _movieconnector.GetAllMovies();
        }
       
        public Movie GetByTitle(string title)
        {
            return _movieconnector.GetByTitle(title);
        }

        public Movie CreateMovie(OmdbMovie omdbmovie)
        {
            if (Int32.Parse(omdbmovie.Year) < 1900 ||
                Int32.Parse(omdbmovie.Year) > Int32.Parse(DateTime.Now.AddYears(6).Year.ToString())){
                throw new ArgumentException(String.Format("Movie Year must be between 1900 and {0}",
                    DateTime.Now.AddYears(6).Year.ToString()));
            }
            else
            {
                try
                {
                    var movie = new Movie()
                    {
                        ImdbId = omdbmovie.ImdbId,
                        Title = omdbmovie.Title,
                        Year = new DateTime(int.Parse(omdbmovie.Year), 1, 1),
                        Rated = omdbmovie.Rated,
                        Released = DateTime.Parse(omdbmovie.Released),
                        Genre = omdbmovie.Genre,
                        Director = omdbmovie.Director,
                        Writer = omdbmovie.Writer,
                        Plot = omdbmovie.Plot,
                        Language = omdbmovie.Language,
                        Country = omdbmovie.Country,
                        Awards = omdbmovie.Awards,
                        Poster = omdbmovie.Poster,
                        Metascore = omdbmovie.Metascore,
                        ImdbRating = omdbmovie.ImdbRating,
                        ImdbVotes = omdbmovie.ImdbVotes,
                        Type = omdbmovie.Type,
                        Response = omdbmovie.Response,
                        Actors = _actorprocessor.GetActorsByString(omdbmovie.Actors)
                    };
                    return _movieconnector.CreateMovie(movie);
                }
                catch (ArgumentException e)
                {
                    throw;
                }
            }
        }
    }
}
