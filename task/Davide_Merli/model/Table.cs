using model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libs;

namespace model
{
    public class Table : ITable
    {
        private static readonly List<Role> totalRoles = new List<Role>
        {
            Role.Sheriff, Role.Renegade, Role.Outlaw, Role.Outlaw, Role.Deputy, Role.Outlaw, Role.Deputy
        };

        //public IDeck { get; }
        public List<Card> DiscardPile { get; }
        public CircularList<SimplePlayer> Players { get; }
        public IPlayer CurrentPlayer { get; set; }
        public List<Card> UsedCards { get; }

        public Table(/*IDeck deck,*/ int playerNumber)
        {
            //this.IDeck = deck;
            this.Players = this.GetPlayersFromNumber(playerNumber);
            //this.GetFirstCards();
            this.CurrentPlayer = this.Players.GetCurrentElement();
        }

        private CircularList<Player> GetPlayersFromNumber(int playerNumber)
        {
            List<Role> roles = totalRoles.GetRange(0, playerNumber);
            Random random = new Random();
            roles.OrderBy(item => random.Next());
            CircularList<Player> players = new CircularList<IPlayer>();
            for(int i = 0; i < playerNumber; i++)
            {
                Role role = roles[i];
                players.Add(new Player(role, "player " + i));
                if (role.Equals(Role.Sheriff))
                {
                    players.CurrentIndex = i;
                }
            }
            return players;
        }

        //private void GetFirstCards()
        //{
        //    this.Players.ForEach(p => this.deck.NextCards(p.LifePoints).ForEach(c => p.AddCard(c)));
        //}

        public void DiscardCard(Card card)
        {
            this.DiscardPile.Add(card);
        }
        public void RemovePlayer(Player player)
        {
            this.Players.Remove(player);
        }

        public void NextPlayer()
        {
            this.UsedCards.Clear();
            this.CurrentPlayer = this.Players.GetNext();
        }
    }
}
