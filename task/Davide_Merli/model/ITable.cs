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

        /// <summary>
        /// Adds a card to the discard pile.
        /// </summary>
        /// 
        /// <param name="card">the card to discard</param>
        void DiscardCard(Card card);

        /// <summary>
        /// Removes player from a list of players.
        /// </summary>
        /// 
        /// <param name="player">the player to remove</param>
        void RemovePlayer(IPlayer player);

        /// <summary>
        /// Sets next player.
        /// </summary>
        void NextPlayer();

        /// <summary>
        /// Adds a card to the list of cards used in current turn.
        /// </summary>
        /// 
        /// <param name="cardName">the used card</param>
        void PlayerUsedCard(string cardName);

        /// <summary>
        /// Sets the possible targets of an action.
        /// </summary>
        /// 
        /// <param name="chosenPlayerSet">the set of targets</param>
        void ChoosePlayer(ISet<IPlayer> chosenPlayerSet);
    }
}
