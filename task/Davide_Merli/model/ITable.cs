using model;
using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
///     An interface implementing a game table.
///     The interface contains functions to handle the players and the deck.
/// </summary>
/// 
/// <author>Davide Merli</author>
namespace task.Davide_Merli.model
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

        void RemovePlayer(Player player);

        void NextPlayer();


    }
}
