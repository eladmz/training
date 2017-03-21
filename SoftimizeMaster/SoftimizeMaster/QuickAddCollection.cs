using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftimizeMaster
{
    /// <summary>
    /// Represents strongly typed collection that quickly adds elements.
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the collection.</typeparam>
    public class QuickAddCollection<T> : QuickCollection<T>
    {
        /// <summary>
        /// Initializes a new instance of the QuickAddCollection<T> with the provided comparer.
        /// </summary>
        /// <param name="comparer">Specify how elements will be compared.</param>
        public QuickAddCollection(IComparer<T> comparer)
        {
            if (comparer == null) throw new ArgumentNullException("Comparer must not be null");

            this.collection = new LinkedList<T>();
            this.comparer = comparer;
        }

        /// <summary>
        /// Adds an element to the collection.
        /// This operation has WC time complexity of O(1).
        /// </summary>
        /// <param name="element">The element to add to the collection.</param>
        /// <returns></returns>
        protected override bool AddElement(T element)
        {
            collection.AddFirst(element);

            return true;
        }

        /// <summary>
        /// Removes the element with the maximum value and returns it.
        /// This operation has WC time complexity of O(n).
        /// </summary>
        /// <returns>The element with the maximum value.</returns>
        protected override T RemoveElement()
        {
            var tempNode = collection.First;
            var maxValueNode = collection.First;

            while(tempNode.Next != null)
            {
                if (comparer.Compare(maxValueNode.Value, tempNode.Next.Value) < 0)
                {
                    maxValueNode = tempNode.Next;
                }
                tempNode = tempNode.Next;
            }

            T maxValue = maxValueNode.Value;
            collection.Remove(maxValueNode);

            return maxValue;
        }
    }
}
