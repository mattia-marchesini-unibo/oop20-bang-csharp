using System;
using model.states;
using libs.observe;

/// <summary>
/// A class which handles the changes of states of the game.
/// </summary>
/// 
/// <author>Davide Merli</author>
namespace model
{
    public class GameStateMachine
    {
        public IState CurrentState { get; set; }
        public ITable Table { get; }
        public ObservableElement<String> MessageObs { get; } = new ObservableElement<string>();


        public GameStateMachine(ITable table)
        {
            this.Table = table;
        }

        /// <summary>
        /// Handles current state
        /// </summary>
        public void Go()
        {
            this.CurrentState.handle(this);
        }

        /// <summary>
        /// Sets the message of the observable.
        /// </summary>
        /// 
        /// <param name="message">the message to set</param>
        public void SetMessage(string message)
        {
            this.MessageObs.Element = message;
        }
    }
}
