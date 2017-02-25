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
    public class ActorTagController_Tests
    {
        private IActorTagCoupler _fakeactortagcoupler = null;
        private IActorTagController _actortagcontroller = null;

        [SetUp]
        public void Setup()
        {
            _fakeactortagcoupler = A.Fake<IActorTagCoupler>();
            _actortagcontroller = new ActorTagController(_fakeactortagcoupler);
        }

        [Test]
        public void Controller_Getting_All_From_Processor()
        {
            var actortags = new List<ActorTag>();
            A.CallTo(() => _fakeactortagcoupler.GetAllTags()).Returns(actortags);

            _actortagcontroller.Get();

            A.CallTo(() =>
                _fakeactortagcoupler.GetAllTags()).MustHaveHappened();
        }

        [Test]
        public void Controller_Get_Single_ActorTag_From_Processor()
        {
            var actortag = A.Fake<ActorTag>();
            actortag.TagId = 1;
            A.CallTo(() => _fakeactortagcoupler.GetById(actortag.TagId)).Returns(actortag);

            _actortagcontroller.Get(actortag.TagId);

            A.CallTo(() =>
                _fakeactortagcoupler.GetById(actortag.TagId)).MustHaveHappened();
        }

        [Test]
        public void Controller_Posting_To_Processor()
        {
            var actortag = A.Fake<ActorTag>();
            A.CallTo(() => _fakeactortagcoupler.CreateTag(actortag, 1)).Returns(actortag);

            _actortagcontroller.Post(actortag, 1);

            A.CallTo(() =>
                _fakeactortagcoupler.CreateTag(actortag, 1)).MustHaveHappened();
        }

        [Test]
        public void Controller_Passing_Delete_To_Processor()
        {
            var actortag = A.Fake<ActorTag>();
            var actorid = 1;

            _actortagcontroller.Delete(actortag, actorid);

            A.CallTo(() => _fakeactortagcoupler.DeleteTagRelationship(actortag, actorid)).MustHaveHappened();

        }
    }
}
