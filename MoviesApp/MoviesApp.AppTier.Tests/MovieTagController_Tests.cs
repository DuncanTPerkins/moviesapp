using MoviesApp.BizTier;
using MoviesApp.Models;
using NUnit.Framework;
using System.Collections.Generic;
using FakeItEasy;
using MoviesApp.AppTier.Bridge;
using MoviesApp.Controllers;

namespace MoviesApp.AppTier.Tests
{
    [TestFixture]
    public class MovieTagController_Tests
    {
        private IMovieTagCoupler _fakemovietagcoupler = null;
        private IMovieTagController _movietagcontroller = null;
        [SetUp]
        public void Setup()
        {
            _fakemovietagcoupler = A.Fake<IMovieTagCoupler>();
            _movietagcontroller = new MovieTagController(_fakemovietagcoupler);
        }

        [Test]
        public void Controller_Getting_All_From_Processor()
        {
            var movietags = new List<MovieTag>();
            A.CallTo(() => _fakemovietagcoupler.GetAllTags()).Returns(movietags);

            _movietagcontroller.Get();

            A.CallTo(() =>
            _fakemovietagcoupler.GetAllTags()).MustHaveHappened();
        }

        [Test]
        public void Controller_Get_Single_MovieTag_From_Processor()
        {
            var movietag = A.Fake<MovieTag>();
            movietag.TagId = 1;
            A.CallTo(() => _fakemovietagcoupler.GetById(movietag.TagId)).Returns(movietag);

            _movietagcontroller.Get(movietag.TagId);

            A.CallTo(() =>
            _fakemovietagcoupler.GetById(movietag.TagId)).MustHaveHappened();
        }

        [Test]
        public void Controller_Posting_To_Processor()
        {
            var movietag = A.Fake<MovieTag>();
            A.CallTo(() => _fakemovietagcoupler.CreateTag(movietag, "1")).Returns(movietag);

            _movietagcontroller.Post(movietag, "1");

            A.CallTo(() =>
            _fakemovietagcoupler.CreateTag(movietag, "1")).MustHaveHappened();
        }

        [Test]
        public void Controller_Passing_Delete_To_Processor()
        {
            var movietag = A.Fake<MovieTag>();
            var movieid = "1";

            _movietagcontroller.Delete(movietag, movieid);

            A.CallTo(() => _fakemovietagcoupler.DeleteTagRelationship(movietag, movieid)).MustHaveHappened();
        }

    }
}
