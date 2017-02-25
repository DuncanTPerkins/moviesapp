using System;
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
    public class ActorTagProcessor_Tests
    {
        private IActorTagConnector _fakeactortagconnector = null;
        private IActorTagProcessor _actortagprocessor = null;
        [SetUp]
        public void Setup()
        {
            _fakeactortagconnector = A.Fake<IActorTagConnector>();
            _actortagprocessor = new ActorTagProcessor(_fakeactortagconnector);
        }

        [Test]
        public void Processor_Getting_All_From_Provider()
        {
            var actortags = new List<ActorTag>();
            A.CallTo(() => _fakeactortagconnector.GetAllTags()).Returns(actortags);

            _actortagprocessor.GetAllTags();

            A.CallTo(() =>
            _fakeactortagconnector.GetAllTags()).MustHaveHappened();
        }

        [Test]
        public void Processor_Get_Single_ActorTag_From_Provider()
        {
            var actortag = A.Fake<ActorTag>();
            actortag.TagId = 1;
            A.CallTo(() => _fakeactortagconnector.GetById(actortag.TagId)).Returns(actortag);

            _actortagprocessor.GetById(actortag.TagId);

            A.CallTo(() =>
            _fakeactortagconnector.GetById(actortag.TagId)).MustHaveHappened();
        }

        [Test]
        public void Processor_Posting_To_Provider()
        {
            var actortag = A.Fake<ActorTag>();
            A.CallTo(() => _fakeactortagconnector.CreateTag(actortag, 1)).Returns(actortag);

            _actortagprocessor.CreateTag(actortag, 1);

            A.CallTo(() =>
            _fakeactortagconnector.CreateTag(actortag, 1)).MustHaveHappened();
        }

        [Test]
        public void Processor_Passing_Delete_To_Provider()
        {
            var actortag = A.Fake<ActorTag>();

            _actortagprocessor.DeleteTagRelationship(actortag, 1);

            A.CallTo(() => _fakeactortagconnector.DeleteTagRelationship(actortag, 1)).MustHaveHappened();

        }

    }
}
