namespace libs.observe
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
