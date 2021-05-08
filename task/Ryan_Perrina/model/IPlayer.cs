using System;
using System.Collections.Generic;

namespace model
{
    public interface IPlayer
    {
        int Sight { get; }

        /// <summary>
        /// Returns a list containing the hand of cards of the player.
        /// </summary>
        /// <returns>a list of cards</returns>
        public List<Card> GetCards();

        /// <summary>
        /// Adds a card to the hand of cards of the player.
        /// </summary>
        /// <param name="Card"></param>
        /// <param name=""></param>
        public void AddCard(Card card);

        /// <summary>
        /// Removes a card from the hand of the player.
        /// </summary>
        /// <param name="Card"></param>
        /// <param name=""></param>
        public void RemoveCard(Card card);

        /// <summary>
        /// Returns a list containing the active cards of the player.
        /// </summary>
        /// <returns>a list of cards</returns>
        public List<Card> GetActiveCards();

        /// <summary>
        ///  Adds a card to the list of active cards.
        /// </summary>
        /// <param name="Card"></param>
        /// <param name=""></param>
        public void AddActiveCard(Card card);

        /// <summary>
        /// Removes a card from the active cards of the player.
        /// </summary>
        /// <param name="Card"></param>
        /// <param name=""></param>
        public void RemoveActiveCard(Card card);

        /// <summary>
        /// Returns a list of cards with an input name, taken from the hand of the
        ///player.
        /// </summary>
        /// <param name="String"></param>
        /// <param name=""></param>
        /// <returns></returns>
        List<Card> GetCardsByName(String name);

        /// <summary>
        ///  Returns a list of cards with an input name, taken from the active cards of
        /// the player.
        /// </summary>
        /// <param name="String"></param>
        /// <param name=""></param>
        /// <returns></returns>
        List<Card> GetActiveCardsByName(String name);

        /// <summary>
        /// Plays a card.
        /// </summary>
        /// <param name="String"></param>
        /// <param name=""></param>
        /// <param name="Table"></param>
        /// <param name=""></param>
        void PlayCard(String name, Table table);

        /// <summary>
        /// Adds a protection.
        /// </summary>
        void AddProtection();

        /// <summary>
        /// Removes a protection.
        /// </summary>
        void RemoveProtection();

        /// <summary>
        ///  Returns true if the player has a protection
        /// </summary>
        /// <returns></returns>
        bool HasProtection();


        /// <summary>
        ///  Adds a weapon to the player.
        /// </summary>
        /// <param name="String"></param>
        /// <param name=""></param>
        void AddWeapon(String card);

        /// <summary>
        ///  Removes the player weapon.
        /// </summary>
        void RemoveWeapon();

        /// <summary>
        /// Return the Name of the player
        /// </summary>
        public String Name { get; }
        /// <summary>
        /// get and set the retreat of the player
        /// </summary>
        public int Retreat { get; set; }
        /// <summary>
        /// return the Role
        /// </summary>
        private Role role { get; }

        /// <summary>
        /// get and set protection of the player
        /// </summary>
        public int Protection { get; set; }
        /// <summary>
        /// return if the  current playerhave a prison or not
        /// and give prison to the player
        /// </summary>
        private bool HasPrison { get; set; }
    }
}
