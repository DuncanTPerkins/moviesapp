using MoviesApp.BizTier;
using MoviesApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using FakeItEasy;
using MoviesApp.AppTier.Bridge;
using MoviesApp.Controllers;

namespace MoviesApp.AppTier.Tests
{
    [TestFixture]
    public class MovieController_Tests
    {
        private IMovieCoupler _fakemoviecoupler = null;
        private IMovieController _moviecontroller = null;
        [SetUp]
        public void Setup()
        {
            _fakemoviecoupler = A.Fake<IMovieCoupler>();
            _moviecontroller = new MovieController(_fakemoviecoupler);
        }

        [Test]
        public void Controller_Getting_All_From_Processor()
        {
            var movies = new List<Movie>();
            A.CallTo(() => _fakemoviecoupler.GetAllMovies()).Returns(movies);

            _moviecontroller.Get();

            A.CallTo(() =>
            _fakemoviecoupler.GetAllMovies()).MustHaveHappened();
        }

        [Test]
        public void Controller_Get_Single_Movie_From_Processor()
        {
            var movie = A.Fake<Movie>();
            movie.ImdbId = "12345";
            A.CallTo(() => _fakemoviecoupler.GetById(movie.ImdbId)).Returns(movie);

            _moviecontroller.GetById(movie.ImdbId);

            A.CallTo(() =>
            _fakemoviecoupler.GetById(movie.ImdbId)).MustHaveHappened();
        }

        [Test]
        public void Controller_Get_Single_Movie_From_Processor_By_Name()
        {
            var movie = A.Fake<Movie>();
            movie.Title = "Star Wars";
            A.CallTo(() => _fakemoviecoupler.GetByTitle(movie.Title)).Returns(movie);

            _moviecontroller.Get(movie.Title);

            A.CallTo(() => _fakemoviecoupler.GetByTitle((movie.Title))).MustHaveHappened();
        }

        [Test]
        public void Controller_Posting_To_Processor_Successfully()
        {
            var omdbmovie = A.Fake<OmdbMovie>();
            var movie = A.Fake<Movie>();
            A.CallTo(() => _fakemoviecoupler.CreateMovie(omdbmovie)).Returns(movie);

            var returnvalue = _moviecontroller.Post(omdbmovie);

            A.CallTo(() =>
            _fakemoviecoupler.CreateMovie(omdbmovie)).MustHaveHappened();
            Assert.That(returnvalue is OkNegotiatedContentResult<Movie>);
        }

        [Test]
        public void Controller_Posting_To_Processor_UnSuccessfully()
        {
            var ex = new ArgumentException();
            var omdbmovie = A.Fake<OmdbMovie>();
            var movie = A.Fake<Movie>();
            A.CallTo(() => _fakemoviecoupler.CreateMovie(omdbmovie)).Throws(ex);

            var returnvalue = _moviecontroller.Post(omdbmovie);

            A.CallTo(() =>
            _fakemoviecoupler.CreateMovie(omdbmovie)).MustHaveHappened();
            Assert.That(returnvalue is BadRequestErrorMessageResult);
        }
    }
}
