using System;
using System.Collections.Generic;

/// <summary>
/// A utility class that implements a circular list.
/// The class contains information about a current element, and has methods which
/// allow the user to get the next and previous element in the list.
/// </summary>
/// 
/// <author>Davide Merli</author>
namespace task.Davide_Merli.libs
{
    public class CircularList<T> : List<T>
    {

        private int currentIndex = 0;
        public int CurrentIndex
        {
            get { return this.currentIndex; }

            set
            {
                if (value < this.Capacity)
                {
                    this.currentIndex = value;
                }
            }
        }

        public CircularList(List<T> list)
        {
            this.AddRange(list);
        }

        public CircularList()
        {
        }

        /// <summary>
        /// Returns current element</summary>
        /// <returns>current element</returns>
        public T GetCurrentElement()
        {
            return this[this.CurrentIndex];
        }

        /// <summary>
        /// Sets current element</summary>
        /// <param name="element">the element to set as current</param>
        public void SetCurrentElement(T element)
        {
            if (this.Contains(element))
            {
                this.CurrentIndex = this.IndexOf(element);
            }
        }

        /// <summary>
        /// Changes the current element to the next one</summary>
        /// <returns>next element</returns>
        public T GetNext()
        {
            if (this.CurrentIndex >= this.Count - 1)
            {
                CurrentIndex = 0;
            }
            else
            {
                CurrentIndex++;
            }
            return this[this.CurrentIndex];
        }

        /// <summary>
        /// Gets next element of an input element</summary>
        /// <param name="element">the element whose next is returned</param>
        public T GetNextOf(T element)
        {
            int index;
            if (IndexOf(element) >= this.Count - 1)
            {
                index = 0;
            }
            else
            {
                index = IndexOf(element) + 1;
            }
            return this[index];
        }

        /// <summary>
        /// Changes the current element to the previous one</summary>
        /// <returns>previous element</returns>
        public T GetPrev()
        {
            if (this.CurrentIndex <= 0)
            {
                CurrentIndex = this.Count - 1;
            }
            else
            {
                CurrentIndex--;
            }
            return this[this.CurrentIndex];
        }

        /// <summary>
        /// Gets previous element of an input element</summary>
        /// <param name="element">the element whose previous is returned</param>
        public T GetPrevOf(T element)
        {
            int index;
            if (IndexOf(element) <= 0)
            {
                index = this.Count - 1;
            }
            else
            {
                index = IndexOf(element) - 1;
            }
            return this[index];
        }
    }
}
