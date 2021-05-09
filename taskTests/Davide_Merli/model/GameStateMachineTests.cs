using Microsoft.VisualStudio.TestTools.UnitTesting;
using model;
using System;
using System.Collections.Generic;
using System.Text;

namespace model.Tests
{
    [TestClass()]
    public class GameStateMachineTests
    {
        [TestMethod()]
        public void GameStateMachineTest()
        {
            var gsm = new GameStateMachine(new Table(null, 0));
            Assert.IsNotNull(gsm);
        }

        [TestMethod()]
        public void GoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetMessageTest()
        {
            Assert.Fail();
        }
    }
}