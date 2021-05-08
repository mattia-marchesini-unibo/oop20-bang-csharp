using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Interface that implements a game state.
/// </summary>
/// 
/// <author>Davide Merli</author>
namespace model.states
{
    public interface IState
    {
        /// <summary>
        /// Performs actions.
        /// </summary>
        /// 
        /// <param name="gsMachine">the component which handles the states</param>
        void handle(GameStateMachine gsMachine);
    }
}
