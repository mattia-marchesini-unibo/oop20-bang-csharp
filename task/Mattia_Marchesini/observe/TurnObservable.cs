using System;
using System.Collections.Generic;
using System.Text;

namespace task.Mattia_Marchesini.observe
{
    public class TurnObservable<E> : ObservableElement<E>
    {
        public override void NotifyObservers()
        {
            base.NotifyObservers();
            this.RemoveAllObservers();
        }
    }
}
