using Microsoft.VisualStudio.TestTools.UnitTesting;
using model;
using System;
using System.Collections.Generic;
using model.deck;
using System.Text;
using System.Linq;

namespace model.Tests
{
    [TestClass()]
    public class LogicsTests
    {
        [TestMethod()]
        public void GetTargetsTest()
        {
            Table table = new Table(new Deck(), 4);
            var p = table.CurrentPlayer;
            var list = table.Players;
            var pDx = list.GetNextOf(p);
            var pSx = list.GetPrevOf(p);
            var l = new Logics(table);

            Assert.IsTrue(new HashSet<IPlayer>() { pSx, pDx }.SetEquals(l.GetTargets()));

            pDx.Retreat += 1;
            Assert.IsTrue(new HashSet<IPlayer>() { pSx }.SetEquals(l.GetTargets()));
        }
    }
}