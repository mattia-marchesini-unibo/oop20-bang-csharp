using System;
using System.Collections.Generic;
using System.Text;
using task.Mattia_Marchesini.observe;

/// <summary>
///     An interface implementing a game table.
///     The interface contains functions to handle the players and the deck.
/// </summary>
/// 
/// <author>Davide Merli</author>
namespace model
{
    public interface ITable
    {
        enum Message
        {
            Choose_Player,
            Choose_Player_With_Distance,
            Choose_Card
        }

        void DiscardCard(Card card);

        void RemovePlayer(IPlayer player);

        void NextPlayer();

        void PlayerUsedCard(string cardName);

        void ChoosePlayer(ISet<IPlayer> chosenPlayerSet);
    }
}
