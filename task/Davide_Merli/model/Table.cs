using System;
using System.Collections.Generic;
using System.Linq;
using libs;
using model.deck;
using libs.observe;

namespace model
{
    public class Table : ITable
    {
        private static readonly List<Role> totalRoles = new List<Role>
        {
            Role.SHERIFF, Role.RENEGADE, Role.OUTLAW, Role.OUTLAW, Role.DEPUTY, Role.OUTLAW, Role.DEPUTY
        };

        public IDeck Deck { get; }
        public List<Card> DiscardPile { get; } = new List<Card>();
        public CircularList<IPlayer> Players { get; }
        public IPlayer CurrentPlayer { get; set; }
        public List<string> UsedCards { get; } = new List<string>();

        public TurnObservable<IPlayer> ChoosePlayerObservable { get; set; } = new TurnObservable<IPlayer>();
        public TurnObservable<Dictionary<Card, IPlayer>> ChooseCardsObservable { get; set; } = new TurnObservable<Dictionary<Card, IPlayer>>();
        public ITable.Message Message { get; set; } = default;
        public ISet<IPlayer> ChosenPlayerSet { get; set; }

        public Table(IDeck deck, int playerNumber)
        {
            this.Deck = deck;
            this.Players = this.GetPlayersFromNumber(playerNumber);
            this.GetFirstCards();
            this.CurrentPlayer = this.Players.GetCurrentElement();
        }

        /// <summary>
        /// Creates players and gives them a name and a role.
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <returns></returns>
        private CircularList<IPlayer> GetPlayersFromNumber(int playerNumber)
        {
            List<Role> roles = totalRoles.GetRange(0, playerNumber);
            Random random = new Random();
            roles.OrderBy(item => random.Next());
            CircularList<IPlayer> players = new CircularList<IPlayer>();
            for (int i = 0; i < playerNumber; i++)
            {
                Role role = roles[i];
                players.Add(new Player(role, "player " + i));
                if (role.Equals(Role.SHERIFF))
                {
                    players.CurrentIndex = i;
                }
            }
            return players;
        }

        /// <summary>
        /// Gives each player a number of cards equal to their life points
        ///     at the beginning of the game.
        /// </summary>
        private void GetFirstCards()
        {
            this.Players.ForEach(p => this.Deck.NextCards(p.LifePoints).ForEach(c => p.AddCard(c)));
        }

        public void DiscardCard(Card card)
        {
            this.DiscardPile.Add(card);
        }

        public void RemovePlayer(IPlayer player)
        {
            this.Players.Remove(player);
        }

        public void NextPlayer()
        {
            this.UsedCards.Clear();
            this.CurrentPlayer = this.Players.GetNext();
        }

        public void PlayerUsedCard(string cardName)
        {
            this.UsedCards.Add(cardName);
        }

        public void ChoosePlayer(ISet<IPlayer> chosenPlayerSet)
        {
            this.Message = ITable.Message.CHOOSE_PLAYER;
            this.ChosenPlayerSet = chosenPlayerSet;
        }
    }
}
