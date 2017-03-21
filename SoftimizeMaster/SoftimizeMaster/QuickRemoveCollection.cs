using System;
using System.Collections.Generic;

namespace SoftimizeMaster
{
    /// <summary>
    /// Represents strongly typed collection that quickly removes elements.
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the collection.</typeparam>
    public class QuickRemoveCollection<T> : QuickCollection<T>
    {
        /// <summary>
        /// Initializes a new instance of the QuickRemoveCollection<T> with the provided comparer.
        /// </summary>
        /// <param name="comparer">Specify how elements will be compared.</param>
        public QuickRemoveCollection(IComparer<T> comparer)
        {
            if (comparer == null) throw new ArgumentNullException("Comparer must not be null");

            this.collection = new LinkedList<T>();
            this.comparer = comparer;
        }

        /// <summary>
        /// Adds an element to the sorted collection according to the comparer.
        /// This operation has WC time complexity of O(n).
        /// </summary>
        /// <param name="element">The element to add to the collection.</param>
        /// <returns></returns>
        protected override bool AddElement(T element)
        {
            if (Count == 0 || comparer.Compare(element, collection.First.Value) <= 0)
            {
                collection.AddFirst(element);
            }
            else if (comparer.Compare(element, collection.Last.Value) >= 0)
            {
                collection.AddLast(element);
            }
            else
            {
                var greaterNode = collection.First;

                while (comparer.Compare(element, greaterNode.Value) > 0)
                {
                    greaterNode = greaterNode.Next;
                }

                collection.AddBefore(greaterNode, element);
            }

            return true;
        }

        /// <summary>
        /// Removes the element with the maximum value and returns it.
        /// This operation has WC time complexity of O(1).
        /// </summary>
        /// <returns>The element with the maximum value.</returns>
        protected override T RemoveElement()
        {
            T maxValue = collection.Last.Value;
            collection.RemoveLast();

            return maxValue;
        }
    }
}
