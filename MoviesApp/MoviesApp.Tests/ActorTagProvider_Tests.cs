using MoviesApp.BizTier;
using MoviesApp.Models;
using NUnit.Framework;
using System.Collections.Generic;
using FakeItEasy;
using MoviesApp.Controllers;

namespace MoviesApp.AppTier.Tests
{
    [TestFixture]
    public class ActorTagController_Tests
    {
        private IActorTagProcessor _fakeactortagprocessor = null;
        private IActorTagController _actortagcontroller = null;
        [SetUp]
        public void Setup()
        {
            _fakeactortagprocessor = A.Fake<IActorTagProcessor>();
            _actortagcontroller = new ActorTagController(_fakeactortagprocessor);
        }

        [Test]
        public void Controller_Getting_All_From_Processor()
        {
            var actortags = new List<ActorTag>();
            A.CallTo(() => _fakeactortagprocessor.GetAllTags()).Returns(actortags);

            _actortagcontroller.Get();

            A.CallTo(() =>
            _fakeactortagprocessor.GetAllTags()).MustHaveHappened();
        }

        [Test]
        public void Controller_Get_Single_ActorTag_From_Processor()
        {
            var actortag = A.Fake<ActorTag>();
            actortag.TagId = 1;
            A.CallTo(() => _fakeactortagprocessor.GetById(actortag.TagId)).Returns(actortag);

            _actortagcontroller.Get(actortag.TagId);

            A.CallTo(() =>
            _fakeactortagprocessor.GetById(actortag.TagId)).MustHaveHappened();
        }

        [Test]
        public void Controller_Posting_To_Processor()
        {
            var actortag = A.Fake<ActorTag>();
            A.CallTo(() => _fakeactortagprocessor.CreateTag(actortag, 1)).Returns(actortag);

            _actortagcontroller.Post(actortag, 1);

            A.CallTo(() =>
            _fakeactortagprocessor.CreateTag(actortag, 1)).MustHaveHappened();
        }

    }
}
