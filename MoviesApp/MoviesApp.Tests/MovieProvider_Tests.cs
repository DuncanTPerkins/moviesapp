using MoviesApp.BizTier;
using MoviesApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using MoviesApp.Controllers;

namespace MoviesApp.AppTier.Tests
{
    [TestFixture]
    public class MovieController_Tests
    {
        private IMovieProcessor _fakemovieprocessor = null;
        private IMovieController _moviecontroller = null;
        [SetUp]
        public void Setup()
        {
            _fakemovieprocessor = A.Fake<IMovieProcessor>();
            _moviecontroller = new MovieController(_fakemovieprocessor);
        }

        [Test]
        public void Controller_Getting_All_From_Processor()
        {
            var movies = new List<Movie>();
            A.CallTo(() => _fakemovieprocessor.GetAllMovies()).Returns(movies);

            _moviecontroller.Get();

            A.CallTo(() =>
            _fakemovieprocessor.GetAllMovies()).MustHaveHappened();
        }

        [Test]
        public void Controller_Get_Single_Movie_From_Processor()
        {
            var movie = A.Fake<Movie>();
            movie.ImdbId = "12345";
            A.CallTo(() => _fakemovieprocessor.GetById(movie.ImdbId)).Returns(movie);

            _moviecontroller.GetById(movie.ImdbId);

            A.CallTo(() =>
            _fakemovieprocessor.GetById(movie.ImdbId)).MustHaveHappened();
        }

        [Test]
        public void Controller_Get_Single_Movie_From_Processor_By_Name()
        {
            var movie = A.Fake<Movie>();
            movie.Title = "Star Wars";
            A.CallTo(() => _fakemovieprocessor.GetByTitle(movie.Title)).Returns(movie);

            _moviecontroller.Get(movie.Title);

            A.CallTo(() => _fakemovieprocessor.GetByTitle((movie.Title))).MustHaveHappened();
        }

        [Test]
        public void Controller_Posting_To_Processor()
        {
            var omdbmovie = A.Fake<OmdbMovie>();
            var movie = A.Fake<Movie>();
            A.CallTo(() => _fakemovieprocessor.CreateMovie(omdbmovie)).Returns(movie);

            _moviecontroller.Post(omdbmovie);

            A.CallTo(() =>
            _fakemovieprocessor.CreateMovie(omdbmovie)).MustHaveHappened();
        }

    }
}
