using System;
using System.Collections.Generic;
using System.Text;

namespace task.Mattia_Marchesini.deck
{
    public class Deck : AbstractDeck
    {
        public Deck() : base(new JSONDeckReader()) { }
    }
}
