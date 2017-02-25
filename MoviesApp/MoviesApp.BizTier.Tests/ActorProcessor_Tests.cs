using MoviesApp.BizTier;
using MoviesApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using FakeItEasy;
using MoviesApp.BizTier.Bridge;

namespace MoviesApp.AppTier.Tests
{
    [TestFixture]
    public class ActorProcessor_Tests
    {
        private IActorConnector _fakeactorprovider = null;
        private IActorProcessor _actorprocessor = null;
        [SetUp]
        public void Setup()
        {
            _fakeactorprovider = A.Fake<IActorConnector>();
            _actorprocessor = new ActorProcessor(_fakeactorprovider);
        }

        [Test]
        public void Processor_Getting_All_From_Provider()
        {
            var actors = new List<Actor>();
            A.CallTo(() => _fakeactorprovider.GetAllActors()).Returns(actors);

            _actorprocessor.GetAllActors();

            A.CallTo(() =>
            _fakeactorprovider.GetAllActors()).MustHaveHappened();
        }

        [Test]
        public void Processor_Get_Single_Actor_From_Provider()
        {
            var actor = A.Fake<Actor>();
            actor.ActorId = 1;
            A.CallTo(() => _fakeactorprovider.GetById(actor.ActorId)).Returns(actor);

            _actorprocessor.GetById(actor.ActorId);

            A.CallTo(() =>
            _fakeactorprovider.GetById(actor.ActorId)).MustHaveHappened();
        }

        [Test]
        public void Processor_Get_Single_Actor_From_Provider_By_Name()
        {
            var actor = A.Fake<Actor>();
            actor.Name = "Bob";
            A.CallTo(() => _fakeactorprovider.GetByName(actor.Name)).Returns(actor);

            _actorprocessor.GetByName(actor.Name);

            A.CallTo(() => _fakeactorprovider.GetByName((actor.Name))).MustHaveHappened();
        }

        [Test]
        public void Processor_Posting_To_Provider()
        {
            var actor = A.Fake<Actor>();
            A.CallTo(() => _fakeactorprovider.CreateActor(actor)).Returns(actor);

            _actorprocessor.CreateActor(actor);

            A.CallTo(() =>
            _fakeactorprovider.CreateActor(actor)).MustHaveHappened();
        }

        [TestCase("bob, mary, tom"), TestCase("Bob; Mary, Tom;"), TestCase("Bob; Mary; Tom"), TestCase("Bob, Mary, Tom;;;")]
        public void Get_Actors_By_String_Throws_Exception_If_Wrong_Delimiter_Is_Used(string actorstring)
        {
            //arrange
            const string DELIMITER = ",";
            //act 
            //assert

            //if string doesn't contain delimiter
            if (actorstring.IndexOf(DELIMITER) == -1)
            {
                var ex = Assert.Throws<System.ArgumentException>(() => _actorprocessor.GetActorsByString(actorstring));
                Assert.That(ex.Message == String.Format("Delimiter in Actor String must be \"{0}\"", DELIMITER));
            }
            //if it does
            else
            {
                var newlist = _actorprocessor.GetActorsByString(actorstring);
                Assert.That(newlist != null);
            }
        }


    }
}
