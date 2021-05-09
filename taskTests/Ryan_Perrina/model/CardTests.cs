using Microsoft.VisualStudio.TestTools.UnitTesting;
using model;
using System;
using System.Collections.Generic;
using System.Text;

namespace model.Tests
{
    [TestClass()]
    public class CardTests
    {
        [TestMethod()]
        public void ColorCardTest()
        {
            Card card = new Card("00", "blue", "bang", "bang");
            Assert.AreEqual(Color.BLUE, card.Color);
        }

        [TestMethod()]
        public void CardTest()
        {
            Card card = new Card("00", "blue", "bang", "bang");

            Assert.IsNull(card.Effect);
        }
    }
}