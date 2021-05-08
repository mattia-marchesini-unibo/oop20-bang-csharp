using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace model.deck.Tests
{
    [TestClass()]
    public class JSONDeckReaderTests
    {
        [TestMethod()]
        public void ReadCardsTest()
        {
            JSONDeckReader reader = new JSONDeckReader();
            Assert.AreEqual(
                new List<Card>()
                {
                    new Card(cardId: "prova0", realName: "prova", localName: "prova", color: "blue")
                },
                reader.ReadCards()
            );
        }
    }
}