using model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace task.Mattia_Marchesini.deck
{
    public abstract class AbstractDeck : IDeck
    {
        private readonly IDeckReader reader;
        private List<Card> cards = null;

        public List<Card> Cards { get => cards; }

        public AbstractDeck(IDeckReader reader)
        {
            this.reader = reader;
        }

        public void NewGame()
        {
            this.cards = new List<Card>(reader.ReadCards());
            this.ShuffleDeck();
        }

        public Card NextCard()
        {
            if (this.cards == null || this.RemainigCards() <= 5)
            {
                this.NewGame();
            }
            Card c = this.cards[0];
            this.cards.RemoveAt(0);
            return c;
        }

        public List<Card> NextCards(int step)
        {
            List<Card> cardList = new List<Card>();
            for(int i = 0; i < step; i++)
            {
                cardList.Add(this.NextCard());
            }
            return cardList;
        }

        public int RemainigCards() => this.cards.Count;

        public void ShuffleDeck()
        {
            Random r = new Random();
            this.cards = this.cards.OrderBy(x => r.Next()).ToList();
        }

        public override bool Equals(object obj)
        {
            return obj is AbstractDeck deck &&
                   EqualityComparer<IDeckReader>.Default.Equals(reader, deck.reader) &&
                   EqualityComparer<List<Card>>.Default.Equals(cards, deck.cards) &&
                   EqualityComparer<List<Card>>.Default.Equals(Cards, deck.Cards);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(reader, cards, Cards);
        }
    }
}
