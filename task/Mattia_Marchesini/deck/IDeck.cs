using model;
using System.Collections.Generic;

namespace task.Mattia_Marchesini.deck
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
