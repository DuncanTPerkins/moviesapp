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
    public class ActorController_Tests
    {
        private IActorProcessor _fakeactorprocessor = null;
        private IActorController _actorcontroller = null;
        [SetUp]
        public void Setup()
        {
            _fakeactorprocessor = A.Fake<IActorProcessor>();
            _actorcontroller = new ActorController(_fakeactorprocessor);
        }

        [Test]
        public void Controller_Getting_All_From_Processor()
        {
            var actors = new List<Actor>();
            A.CallTo(() => _fakeactorprocessor.GetAllActors()).Returns(actors);

            _actorcontroller.Get();

            A.CallTo(() =>
            _fakeactorprocessor.GetAllActors()).MustHaveHappened();
        }

        [Test]
        public void Controller_Get_Single_Actor_From_Processor()
        {
            var actor = A.Fake<Actor>();
            actor.ActorId = 1;
            A.CallTo(() => _fakeactorprocessor.GetById(actor.ActorId)).Returns(actor);

            _actorcontroller.Get(actor.ActorId);

            A.CallTo(() =>
            _fakeactorprocessor.GetById(actor.ActorId)).MustHaveHappened();
        }

        [Test]
        public void Controller_Get_Single_Actor_From_Processor_By_Name()
        {
            var actor = A.Fake<Actor>();
            actor.Name = "Bob";
            A.CallTo(() => _fakeactorprocessor.GetByName(actor.Name)).Returns(actor);

            _actorcontroller.Get(actor.Name);

            A.CallTo(() => _fakeactorprocessor.GetByName((actor.Name))).MustHaveHappened();
        }

        [Test]
        public void Controller_Posting_To_Processor()
        {
            var actor = A.Fake<Actor>();
            A.CallTo(() => _fakeactorprocessor.CreateActor(actor)).Returns(actor);

            _actorcontroller.Post(actor);

            A.CallTo(() =>
            _fakeactorprocessor.CreateActor(actor)).MustHaveHappened();
        }

    }
}
