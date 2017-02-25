using MoviesApp.Models;
using NUnit.Framework;
using System.Collections.Generic;
using FakeItEasy;
using MoviesApp.Controllers;
using MoviesApp.AppTier.Bridge;

namespace MoviesApp.AppTier.Tests
{
    [TestFixture]
    public class ActorController_Tests
    {
        private IActorCoupler _fakeactorcoupler = null;
        private IActorController _actorcontroller = null;
        [SetUp]
        public void Setup()
        {
            _fakeactorcoupler = A.Fake<IActorCoupler>();
            _actorcontroller = new ActorController(_fakeactorcoupler);
        }

        [Test]
        public void Controller_Getting_All_From_Processor()
        {
            var actors = new List<Actor>();
            A.CallTo(() => _fakeactorcoupler.GetAllActors()).Returns(actors);

            _actorcontroller.Get();

            A.CallTo(() =>
            _fakeactorcoupler.GetAllActors()).MustHaveHappened();
        }

        [Test]
        public void Controller_Get_Single_Actor_From_Processor()
        {
            var actor = A.Fake<Actor>();
            actor.ActorId = 1;
            A.CallTo(() => _fakeactorcoupler.GetById(actor.ActorId)).Returns(actor);

            _actorcontroller.Get(actor.ActorId);

            A.CallTo(() =>
            _fakeactorcoupler.GetById(actor.ActorId)).MustHaveHappened();
        }

        [Test]
        public void Controller_Get_Single_Actor_From_Processor_By_Name()
        {
            var actor = A.Fake<Actor>();
            actor.Name = "Bob";
            A.CallTo(() => _fakeactorcoupler.GetByName(actor.Name)).Returns(actor);

            _actorcontroller.Get(actor.Name);

            A.CallTo(() => _fakeactorcoupler.GetByName((actor.Name))).MustHaveHappened();
        }

        [Test]
        public void Controller_Posting_To_Processor()
        {
            var actor = A.Fake<Actor>();
            A.CallTo(() => _fakeactorcoupler.CreateActor(actor)).Returns(actor);

            _actorcontroller.Post(actor);

            A.CallTo(() =>
            _fakeactorcoupler.CreateActor(actor)).MustHaveHappened();
        }
    }
}
