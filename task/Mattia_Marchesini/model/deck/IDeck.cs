using System.Collections.Generic;

namespace model.deck
{
    public interface IDeck
    {
        void NewGame();

        Card NextCard();

        List<Card> NextCards(int step);

        int RemainigCards();

        void ShuffleDeck();
    }
}
