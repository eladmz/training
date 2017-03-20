using System;
using System.Collections.Generic;

namespace SoftimizeMaster
{
    /// <summary>
    /// Represents strongly typed abstarct collection that notifies to subscribers upon any add or remove.
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the collection.</typeparam>
    public abstract class QuickCollection<T>
    {
        protected LinkedList<T> collection;
        protected IComparer<T> comparer;

        public event EventHandler<CollectionChangedEventArgs<T>> CollectionChanged;

        /// <summary>
        /// Get the number of elements actually in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                lock (collection)
                {
                    return collection.Count;
                }
            }
        }

        /// <summary>
        /// Adds an element to the collection and publishes it. 
        /// </summary>
        /// <param name="element">The element to add to the collection.</param>
        /// <returns></returns>
        public bool Add(T element)
        {
            if (element == null) throw new ArgumentNullException("Provided element must not be null");

            var success = true;
            lock (collection)
            {
                success = AddElement(element);
            }

            if (success)
            {
                var eventArgs = new CollectionChangedEventArgs<T>(ActionType.Add, element);
                Publish(eventArgs);
            }
            return success;
        }

        protected abstract bool AddElement(T element);

        /// <summary>
        /// Removes the element with the maximum value, returns it and publish to subscribers.
        /// </summary>
        /// <returns></returns>
        public T Remove()
        {
            var maxValue = default(T);
            lock (collection)
            {
                if (Count == 0) throw new IndexOutOfRangeException("The collection is empty");

                maxValue = RemoveElement();
            }

            var eventArgs = new CollectionChangedEventArgs<T>(ActionType.Remove, maxValue);
            Publish(eventArgs);

            return maxValue;
        }

        protected abstract T RemoveElement();

        /// <summary>
        /// publishes notification to anyone subscribed to the event.
        /// </summary>
        /// <param name="eventArgs"></param>
        protected virtual void Publish(CollectionChangedEventArgs<T> eventArgs)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, eventArgs);
            }
        }
    }
}
