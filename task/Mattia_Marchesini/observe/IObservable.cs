namespace libs.observe
{
    interface IObservable
    {
        void AddObserver(Observer observer);

        void RemoveObserver(Observer observer);

        void RemoveAllObservers();

        void NotifyObservers();
    }
}
