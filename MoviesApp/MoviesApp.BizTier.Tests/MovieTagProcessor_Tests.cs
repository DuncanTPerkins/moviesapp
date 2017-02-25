using MoviesApp.BizTier;
using MoviesApp.Models;
using NUnit.Framework;
using System.Collections.Generic;
using FakeItEasy;
using MoviesApp.BizTier.Bridge;
using MoviesApp.DataTier;

namespace MoviesApp.AppTier.Tests
{
    [TestFixture]
    public class MovieTagProcessor_Tests
    {
        private IMovieTagConnector _fakemovietagconnector = null;
        private IMovieTagProcessor _movietagprocessor = null;
        [SetUp]
        public void Setup()
        {
            _fakemovietagconnector = A.Fake<IMovieTagConnector>();
            _movietagprocessor = new MovieTagProcessor(_fakemovietagconnector);
        }

        [Test]
        public void Processor_Getting_All_From_Provider()
        {
            var movietags = new List<MovieTag>();
            A.CallTo(() => _fakemovietagconnector.GetAllTags()).Returns(movietags);

            _movietagprocessor.GetAllTags();

            A.CallTo(() =>
            _fakemovietagconnector.GetAllTags()).MustHaveHappened();
        }

        [Test]
        public void Processor_Get_Single_MovieTag_From_Provider()
        {
            var movietag = A.Fake<MovieTag>();
            movietag.TagId = 1;
            A.CallTo(() => _fakemovietagconnector.GetById(movietag.TagId)).Returns(movietag);

            _movietagprocessor.GetById(movietag.TagId);

            A.CallTo(() =>
            _fakemovietagconnector.GetById(movietag.TagId)).MustHaveHappened();
        }

        [Test]
        public void Processor_Posting_To_Provider()
        {
            var movietag = A.Fake<MovieTag>();
            A.CallTo(() => _fakemovietagconnector.CreateTag(movietag, "1")).Returns(movietag);

            _movietagprocessor.CreateTag(movietag, "1");

            A.CallTo(() =>
            _fakemovietagconnector.CreateTag(movietag, "1")).MustHaveHappened();
        }

        [Test]
        public void Processor_Passing_Delete_To_Provider()
        {
            var movietag = A.Fake<MovieTag>();

            _movietagprocessor.DeleteTagRelationship(movietag, "1");

            A.CallTo(() => _fakemovietagconnector.DeleteTagRelationship(movietag, "1")).MustHaveHappened();

        }
    }
}
