using Microsoft.VisualStudio.TestTools.UnitTesting;
using model;
using model.deck;
using model.states;

namespace model.Tests
{
    [TestClass()]
    public class GameStateMachineTests
    {
        class State1 : IState
        {
            public void handle(GameStateMachine gsMachine)
            {
                gsMachine.CurrentState = new State2();
            }
        }

        class State2 : IState
        {
            public void handle(GameStateMachine gsMachine)
            {
                gsMachine.CurrentState = new State1();
            }
        }


        [TestMethod()]
        public void GameStateMachineTest()
        {
            var gsm = new GameStateMachine(new Table(new Deck(), 4));
            Assert.IsNotNull(gsm);
        }

        [TestMethod()]
        public void GoTest()
        {
            var gsm = new GameStateMachine(new Table(new Deck(), 4));
            gsm.CurrentState = new State1();
            gsm.Go();
            Assert.AreEqual(new State2().GetType(), gsm.CurrentState.GetType());
        }

        [TestMethod()]
        public void SetMessageTest()
        {
            var gsm = new GameStateMachine(new Table(new Deck(), 4));
            gsm.SetMessage("Message");
            Assert.AreEqual("Message", gsm.MessageObs.Element);
        }
    }
}