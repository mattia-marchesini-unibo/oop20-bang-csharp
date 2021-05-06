using System;
using System.Collections.Generic;

namespace task.Mattia_Marchesini.observe
{
    public class ObservableElement<E> : IObservable
    {
        protected List<Observer> Observers { get; } = new List<Observer>();
        private E element;

        public E Element
        {
            get { return element; }
            set
            {
                this.element = value;
                this.Observers.ForEach(delegate (Observer obs)
                {
                    obs();
                });
            }
        }

        public ObservableElement(E element) => this.element = element;

        public ObservableElement() { }

        public void AddObserver(Observer observer) => this.Observers.Add(observer);

        public void RemoveObserver(Observer observer) => this.Observers.Remove(observer);

        public void RemoveAllObservers() => this.Observers.Clear();

        public void NotifyObservers()
        {
            this.Observers.ForEach(delegate (Observer obs)
            {
                obs();
            });
        }

        public void SetNoNotify(E element) => this.element = element;

        public bool IsEmpty() => this.element == null;

        public override bool Equals(object obj)
        {
            return obj is ObservableElement<E> element &&
                   EqualityComparer<E>.Default.Equals(this.element, element.element);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(element);
        }
    }
}
