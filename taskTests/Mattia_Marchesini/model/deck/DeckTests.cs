using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace model.deck.Tests
{
    [TestClass()]
    public class DeckTests
    {
        const int CARDS_COUNT = 10;

        class FakeDeck : AbstractDeck
        {
            public FakeDeck() : base(new DeckReader()) {}
        }

        class DeckReader : IDeckReader
        {
            public List<Card> ReadCards()
            {
                var list = new List<Card>();
                for (int i = 0; i < CARDS_COUNT; i++)
                {
                    list.Add(new Card("card" + i, Color.Brown.ToString(), "Carta", "Card"));
                }
                return list;
            }
        }

        [TestMethod()]
        public void RemaningCardsTest()
        {
            FakeDeck deck = new FakeDeck();
            deck.NewGame();
            Assert.AreEqual(CARDS_COUNT, deck.RemainigCards());
        }

        [TestMethod()]
        public void ShuffleDeckTest()
        {
            FakeDeck deck = new FakeDeck();
            deck.NewGame();
            List<Card> cards = new List<Card>(deck.Cards);
            deck.ShuffleDeck();
            Assert.AreNotEqual(cards, deck.Cards);
        }

        [TestMethod()]
        public void NextCardTest()
        {
            FakeDeck deck = new FakeDeck();
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
            FakeDeck deck = new FakeDeck();
            deck.NewGame();
            int tot = deck.RemainigCards() + 1;

            Assert.IsNotNull(deck.NextCards(tot));
        }
    }
}