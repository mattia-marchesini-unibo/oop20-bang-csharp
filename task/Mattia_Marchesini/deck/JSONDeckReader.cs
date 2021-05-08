using model;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace task.Mattia_Marchesini.deck
{
    public class JSONDeckReader : IDeckReader
    {

        private const string DECK_FILE = "deck.json";
        private List<Card> cards = null;

		public class JSONCard
        {
			public string localName { get; set; }
			public string realName { get; set; }
			public string color { get; set; }
			public int howMany { get; set; }
		}

        public List<Card> ReadCards()
        {
			if (this.cards == null)
			{
				this.cards = new List<Card>();
				List<JSONCard> c = JsonConvert.DeserializeObject<List<JSONCard>>(File.ReadAllText(DECK_FILE));

				c.ForEach(crd =>
				{
					for (int i = 0; i < crd.howMany; i++)
					{
						this.cards.Add(new Card(crd.realName + i.ToString(), crd.color, crd.localName, crd.realName));
					}
				});
			}
			return cards;
        }
    }
}
