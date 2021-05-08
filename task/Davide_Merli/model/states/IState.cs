using System;
using System.Collections.Generic;
using System.Text;

namespace model.states
{
    public interface IState
    {
        void handle(GameStateMachine gsMachine);
    }
}
