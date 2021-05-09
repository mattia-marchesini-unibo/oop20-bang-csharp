using Microsoft.VisualStudio.TestTools.UnitTesting;
using model.deck;
using System.Collections.Generic;

namespace model.Tests
{
    [TestClass()]
    public class TableTests
    {

        private const int PLAYER_NUM = 4;

        [TestMethod()]
        public void TableTest()
        {
            ITable table = new Table(new Deck(), PLAYER_NUM);
            Assert.AreEqual(table.Players.Count, PLAYER_NUM);
            table.Players.ForEach(p => Assert.AreEqual(p.LifePoints, p.Hand.Count));
            Assert.AreEqual(table.Players.GetCurrentElement(), table.CurrentPlayer);
        }

        [TestMethod()]
        public void DiscardCardTest()
        {
            ITable table = new Table(new Deck(), PLAYER_NUM);
            Card card = table.Deck.NextCard();
            table.DiscardCard(card);
            Assert.IsTrue(table.DiscardPile.Contains(card));
        }

        [TestMethod()]
        public void RemovePlayerTest()
        {
            ITable table = new Table(new Deck(), PLAYER_NUM);
            IPlayer player = table.CurrentPlayer;
            table.RemovePlayer(player);
            Assert.IsFalse(table.Players.Contains(player));
        }

        [TestMethod()]
        public void NextPlayerTest()
        {
            ITable table = new Table(new Deck(), PLAYER_NUM);
            IPlayer player = table.Players.GetNextOf(table.CurrentPlayer);
            table.NextPlayer();
            Assert.AreEqual(table.CurrentPlayer, player);
        }

        [TestMethod()]
        public void PlayerUsedCardTest()
        {
            ITable table = new Table(new Deck(), PLAYER_NUM);
            string card = table.Deck.NextCard().RealName;
            table.PlayerUsedCard(card);
            Assert.IsTrue(table.UsedCards.Contains(card));
        }

        [TestMethod()]
        public void ChoosePlayerTest()
        {
            ITable table = new Table(new Deck(), PLAYER_NUM);
            ISet<IPlayer> chosenPlayers = new HashSet<IPlayer>();
            chosenPlayers.Add(table.CurrentPlayer);
            table.ChoosePlayer(chosenPlayers);
            Assert.AreEqual(table.ChosenPlayerSet, chosenPlayers);
            Assert.AreEqual(ITable.Message.CHOOSE_PLAYER, table.TableMessage);
        }
    }
}