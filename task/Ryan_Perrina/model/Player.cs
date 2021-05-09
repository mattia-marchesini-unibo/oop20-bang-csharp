using System;
using System.Linq;
using System.Collections.Generic;

namespace model
{
	public class Player : IPlayer
	{
		private static readonly int BASIC_SIGHT = 1;
		private static readonly int MAX_LIFE_POINTS = 4;
		private string name;
		public string Name { get; set; }
		private int sight = BASIC_SIGHT;
		public int Sight
		{
			get => sight;
			set
			{
				this.sight += sight;

				if (this.sight < 0)
				{
					this.sight = 0;
				}
			}
		}
		public int Retreat { get; set; }
		private Role role;
		public Role Role { get => role; }
		private List<Card> hand = new List<Card>();
		public List<Card> Hand { get => hand; }
		private List<Card> activeCards = new List<Card>();
		public List<Card> ActiveCards { get; }
		private int lifePoints;
		public int LifePoints
		{
			get => lifePoints;
			set
			{
				int newLifePoints;
				newLifePoints = this.lifePoints + value;
				if (newLifePoints >= this.maxLifePoints)
				{
					this.lifePoints = this.maxLifePoints;
				}
				else if (newLifePoints < 0)
				{
					this.lifePoints = 0;
				}
				else
				{
					this.lifePoints = newLifePoints;
				}
			}
		}
		private int maxLifePoints;
		public int Protection { get; set; }
		public bool HasPrison { get; set; } = false;
		private Card weapon = null;

		
		public Player(Role role, String name)
		{
			this.Retreat = 0;
			this.sight = BASIC_SIGHT;
			this.HasPrison = false;
			this.name = name;
			this.role = role;
			if (this.role.Equals(model.Role.SHERIFF))
			{
				this.maxLifePoints = MAX_LIFE_POINTS + 1;
			}
			else
			{
				this.maxLifePoints = MAX_LIFE_POINTS;
			}
			this.lifePoints = this.maxLifePoints;
		}

		public List<Card> GetCardsByName(String name)
		{
			var temp = new List<Card>();
			this.hand.ForEach(delegate (Card c)
			{
				if (c.RealName.Equals(name))
				{
					temp.Add(c);
				}
			});
			return temp;
		}

		public List<Card> GetActiveCardsByName(String name)
		{
			var temp = new List<Card>();
			this.activeCards.ForEach(delegate (Card c)
			{
				if (c.RealName.Equals(name))
				{
					temp.Add(c);
				}
			});
			return temp;

		}

		public void AddCard(Card card)
		{
			this.hand.Add(card);
		}

		public void PlayCard(String name, Table table)
		{
			Card card = this.GetCardsByName(name).ElementAt(0);

			if (card.Color == Color.BLUE)
			{
                this.AddActiveCard(card);
			}
			this.RemoveCard(card);
			card.Effect.UseEffect(table);
		}

		public void RemoveCard(Card card)
		{
			this.hand.Remove(card);
		}
	
		public void AddActiveCard( Card card)
		{
			this.activeCards.Add(card);
		}

		public void RemoveActiveCard(Card card)
		{
			this.activeCards.Remove(card);
		}

		public void AddProtection()
		{
			this.Protection++;
		}

		public  void RemoveProtection()
		{
			this.Protection--;

			if (this.Protection < 0)
			{
				this.Protection = 0;
			}
		}

		public bool HasProtection()
		{
			return this.Protection > 0;
		}

		public void AddWeapon(String card)
		{
			if (this.weapon != null)
			{
				this.RemoveActiveCard(this.weapon);
			}
			this.weapon = this.GetCardsByName(card).ElementAt(0);
			this.AddActiveCard(this.GetCardsByName(card).ElementAt(0));
		}

		public void RemoveWeapon()
		{
			this.RemoveActiveCard(this.weapon);
			this.weapon = null;
		}
    }
}
