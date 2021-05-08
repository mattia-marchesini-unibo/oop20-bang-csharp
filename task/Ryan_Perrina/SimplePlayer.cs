using System;
using System.Collections.Generic;
using task.Davide_Merli.model;
namespace model
{
	public class SimplePlayer : IPlayer
	{
		private static readonly int BASIC_SIGHT = 1;
		private static readonly int MAX_LIFE_POINTS = 4;
		private String Name { get; }
		private int sight = BASIC_SIGHT;
		public int Retreat { get; set; }
		private Role role { get; }
		private List<Card> hand = new List<Card>();
		private HashSet<Card> activeCards = new HashSet<Card>();
		private int lifePoints;
		private int maxLifePoints;
		public int Protection {get; set;}
		private bool HasPrison { get; set;}
		private Nullable<Card> weapon = null;

		
		public SimplePlayer(Role role, String name)
		{
			this.Retreat = 0;
			this.Sight = BASIC_SIGHT;
			this.HasPrison = false;
			this.Name = name;
			this.role = role;
			if (this.role.equals(Role.SHERIFF))
			{
				this.maxLifePoints = MAX_LIFE_POINTS + 1;
			}
			else
			{
				this.maxLifePoints = MAX_LIFE_POINTS;
			}
			this.LifePoints = this.maxLifePoints;
		}

		public int LifePoints
		{
			get
			{
				return this.sight;
			}
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
		public int Sight
		{
			get
			{
				return this.sight;
			}
			set
			{
				this.sight += sight;

				if (this.sight < 0)
				{
					this.sight = 0;
				}
			}
		}

		public  List<Card> GetCards()
		{
			return this.hand;
		}

		public  List<Card> GetCardsByName(String name)
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

			//return this.hand.stream().filter(c -> c.getRealName().equals(name)).collect(Collectors.toList());
		}

		public  List<Card> GetActiveCardsByName(String name)
		{
			
			return this.activeCards.Stream().Filter(c->c.getRealName().equals(name)).collect(Collectors.toList())


		}

		public void AddCard(Card card)
		{
			this.hand.Add(card);
		}

		public void PlayCard(String name, Table table)
		{
			Card card = this.GetCardsByName(name).Get(0);

			if (card.Color == Color.Blu)
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

		public HashSet<Card> GetActiveCards()
		{
			return this.activeCards;
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
			if (this.weapon.HasValue)
			{
				this.RemoveActiveCard(this.weapon.Value);
			}
			this.weapon = this.GetCardsByName(card).Get(0));
			this.AddActiveCard(this.GetCardsByName(card).Get(0));
		}

		public void RemoveWeapon()
		{
			this.RemoveActiveCard(this.weapon.Value);
			this.weapon = null;
		}
    }
}
