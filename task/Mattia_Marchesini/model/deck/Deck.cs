namespace model.deck
{
    public class Deck : AbstractDeck
    {
        public Deck() : base(new JSONDeckReader()) { }
    }
}
