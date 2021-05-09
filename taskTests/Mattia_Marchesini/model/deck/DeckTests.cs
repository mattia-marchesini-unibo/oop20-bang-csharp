using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace model.deck.Tests
{
    [TestClass()]
    public class DeckTests
    {
        const int CARDS_COUNT = 60;

        [TestMethod()]
        public void RemaningCardsTest()
        {
            Deck deck = new Deck();
            deck.NewGame();
            Assert.AreEqual(CARDS_COUNT, deck.RemainigCards());
        }

        [TestMethod()]
        public void ShuffleDeckTest()
        {
            Deck deck = new Deck();
            deck.NewGame();
            List<Card> cards = new List<Card>(deck.Cards);
            deck.ShuffleDeck();
            Assert.AreNotEqual(cards, deck.Cards);
        }

        [TestMethod()]
        public void NextCardTest()
        {
            Deck deck = new Deck();
            deck.NewGame();
            int tot = deck.RemainigCards() + 1;

            for(int i = 0; i < tot; i++)
            {
                Assert.IsNotNull(deck.NextCard());
            }
        }

        [TestMethod()]
        public void NextCardsTest()
        {
            Deck deck = new Deck();
            deck.NewGame();
            int tot = deck.RemainigCards() + 1;

            Assert.IsNotNull(deck.NextCards(tot));
        }
    }
}