using System;
using System.Collections.Generic;

namespace SoftimizeMaster
{
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

        protected override T RemoveElement()
        {
            T maxValue = collection.Last.Value;
            collection.RemoveLast();

            return maxValue;
        }
    }
}
