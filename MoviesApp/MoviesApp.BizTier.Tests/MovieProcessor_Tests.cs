using MoviesApp.BizTier;
using MoviesApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using FakeItEasy;
using MoviesApp.BizTier.Bridge;
using MoviesApp.DataTier;

namespace MoviesApp.AppTier.Tests
{
    [TestFixture]
    public class MovieProcessor_Tests
    {
        private IMovieConnector _fakemovieconnector = null;
        private IActorProcessor _fakeactorprocessor = null;
        private IMovieProcessor _movieprocessor = null;
        [SetUp]
        public void Setup()
        {
            _fakemovieconnector = A.Fake<IMovieConnector>();
            _fakeactorprocessor = A.Fake<IActorProcessor>();
            _movieprocessor = new MovieProcessor(_fakemovieconnector, _fakeactorprocessor);
        }

        [Test]
        public void Processor_Getting_All_From_Provider()
        {
            var movies = new List<Movie>();
            A.CallTo(() => _fakemovieconnector.GetAllMovies()).Returns(movies);

            _movieprocessor.GetAllMovies();

            A.CallTo(() =>
            _fakemovieconnector.GetAllMovies()).MustHaveHappened();
        }

        [Test]
        public void Processor_Get_Single_Movie_From_Provider()
        {
            var movie = A.Fake<Movie>();
            movie.ImdbId = "12345";
            A.CallTo(() => _fakemovieconnector.GetById(movie.ImdbId)).Returns(movie);

            _movieprocessor.GetById(movie.ImdbId);

            A.CallTo(() =>
            _fakemovieconnector.GetById(movie.ImdbId)).MustHaveHappened();
        }

        [Test]
        public void Processor_Get_Single_Movie_From_Provider_By_Name()
        {
            var movie = A.Fake<Movie>();
            movie.Title = "Star Wars";
            A.CallTo(() => _fakemovieconnector.GetByTitle(movie.Title)).Returns(movie);

            _movieprocessor.GetByTitle(movie.Title);

            A.CallTo(() => _fakemovieconnector.GetByTitle((movie.Title))).MustHaveHappened();
        }

        [Test]
        public void Processor_Posting_To_Provider()
        {
            var omdbmovie = new OmdbMovie()
            {
                ImdbId = "12345",
                Title = "Title",
                Year = "1999",
                Rated = "Yes",
                Released = "08/26/1994",
                Genre = "Yes",
                Director = "yes",
                Writer = "Scott",
                Plot = "pretty good movie",
                Language = "French",
                Country = "America",
                Awards = "A Variety",
                Poster = "Poster Url",
                Metascore = 40,
                ImdbRating = "4000000",
                ImdbVotes = "99999",
                Actors = "Bob, Tom, Harry",
                Type = "Good",
                Response = "Yes"
            };
            A.CallTo(() => _fakeactorprocessor.GetActorsByString(omdbmovie.Actors)).Returns(A.Fake<List<Actor>>());

            _movieprocessor.CreateMovie(omdbmovie);

            A.CallTo(() =>
            _fakemovieconnector.CreateMovie(A<Movie>.Ignored)).MustHaveHappened();
        }

        [TestCase("1900"), TestCase("2012"), TestCase("1760"), TestCase("3000")]
        public void Only_Pass_Movie_To_Provider_If_Year_Is_In_Valid_Range(string year)
        {
            var omdbmovie = new OmdbMovie()
            {
                ImdbId = "12345",
                Title = "Title",
                Year = year,
                Rated = "Yes",
                Released = "08/26/1994",
                Genre = "Yes",
                Director = "yes",
                Writer = "Scott",
                Plot = "pretty good movie",
                Language = "French",
                Country = "America",
                Awards = "A Variety",
                Poster = "Poster Url",
                Metascore = 40,
                ImdbRating = "4000000",
                ImdbVotes = "99999",
                Actors = "Bob, Tom, Harry",
                Type = "Good",
                Response = "Yes"
            };

            A.CallTo(() => _fakeactorprocessor.GetActorsByString(omdbmovie.Actors)).Returns(A.Fake<List<Actor>>());

            //if date is out of bounds
            if (Int32.Parse(year) < 1900 || Int32.Parse(year) > Int32.Parse(DateTime.Now.AddYears(6).Year.ToString()))
            {
                var ex = Assert.Throws<System.ArgumentException>(() => _movieprocessor.CreateMovie(omdbmovie));
                Assert.That(ex.Message == String.Format("Movie Year must be between 1900 and {0}",
                    DateTime.Now.AddYears(6).Year.ToString()));
            }
            //if it's not 
            else
            {
                _movieprocessor.CreateMovie(omdbmovie);
                A.CallTo(() =>
                _fakemovieconnector.CreateMovie(A<Movie>.Ignored)).MustHaveHappened();
            }
        }

    }
}
