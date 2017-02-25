using MoviesApp.BizTier;
using MoviesApp.Models;
using NUnit.Framework;
using System.Collections.Generic;
using FakeItEasy;
using MoviesApp.Controllers;

namespace MoviesApp.AppTier.Tests
{
    [TestFixture]
    public class MovieTagController_Tests
    {
        private IMovieTagProcessor _fakemovietagprocessor = null;
        private IMovieTagController _movietagcontroller = null;
        [SetUp]
        public void Setup()
        {
            _fakemovietagprocessor = A.Fake<IMovieTagProcessor>();
            _movietagcontroller = new MovieTagController(_fakemovietagprocessor);
        }

        [Test]
        public void Controller_Getting_All_From_Processor()
        {
            var movietags = new List<MovieTag>();
            A.CallTo(() => _fakemovietagprocessor.GetAllTags()).Returns(movietags);

            _movietagcontroller.Get();

            A.CallTo(() =>
            _fakemovietagprocessor.GetAllTags()).MustHaveHappened();
        }

        [Test]
        public void Controller_Get_Single_MovieTag_From_Processor()
        {
            var movietag = A.Fake<MovieTag>();
            movietag.TagId = 1;
            A.CallTo(() => _fakemovietagprocessor.GetById(movietag.TagId)).Returns(movietag);

            _movietagcontroller.Get(movietag.TagId);

            A.CallTo(() =>
            _fakemovietagprocessor.GetById(movietag.TagId)).MustHaveHappened();
        }

        [Test]
        public void Controller_Posting_To_Processor()
        {
            var movietag = A.Fake<MovieTag>();
            A.CallTo(() => _fakemovietagprocessor.CreateTag(movietag, "1")).Returns(movietag);

            _movietagcontroller.Post(movietag, "1");

            A.CallTo(() =>
            _fakemovietagprocessor.CreateTag(movietag, "1")).MustHaveHappened();
        }

    }
}
