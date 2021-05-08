using System.Collections.Generic;

namespace model.deck
{
    public interface IDeckReader
    {
        List<Card> ReadCards();
    }
}
