﻿using System;
using System.Collections.Generic;
using System.Text;

namespace task.Davide_Merli.model.states
{
    public interface IState
    {
        void handle(GameStateMachine gsMachine);
    }
}
