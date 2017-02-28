using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class SortedLinkedList<T> where T : IComparable
    {
        private SortedNode<T> first;
        private SortedNode<T> last;
        private int count;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public SortedLinkedList()
        {
            Console.WriteLine("**********Sorted Linked List Created**********");
            first = null;
            last = null;
            count = 0;
        }

        public void Add(T value)
        {
            SortedNode<T> newSortedNode = new SortedNode<T>(value);

            if (IsEmpty())
            {
                first = last = newSortedNode;
            }
            else
            {
                SortedNode<T> currentNode = first;

                while(currentNode != null && currentNode.Value.CompareTo(value) < 0)
                {
                    currentNode = currentNode.Next;
                }

                if (currentNode == null)
                {
                    last.Next = newSortedNode;
                    newSortedNode.Prev = last;
                    last = newSortedNode;
                }
                else
                {
                    newSortedNode.Next = currentNode;
                    newSortedNode.Prev = currentNode.Prev;
                    if (currentNode != first)
                    {
                        currentNode.Prev.Next = newSortedNode;
                    }
                    else
                    {
                        first = newSortedNode;
                    }
                    currentNode.Prev = newSortedNode;
                }
            }

            count++;
        }

        public T RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("The List is Empty!");
            }

            SortedNode<T> nodeToRemove = first;

            first = first.Next;
            first.Prev = null;

            return nodeToRemove.Value;
        }

        public T RemoveLast()
        {
            if (IsEmpty())
            {
                throw new IndexOutOfRangeException("The List is Empty!");
            }

            SortedNode<T> nodeToRemove = last;

            last = last.Prev;
            last.Next = null;

            return nodeToRemove.Value;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public override string ToString()
        {
            SortedNode<T> current = first;

            StringBuilder sb = new StringBuilder();
            while(current != null)
            {
                sb.Append(current.Value);
                sb.Append(", ");
                current = current.Next;
            }
            return sb.ToString();
        }
    }

    class SortedNode<T>
    {
        public SortedNode<T> Next { get; set; }
        public SortedNode<T> Prev { get; set; }
        public T Value { get; set; }

        public SortedNode(T value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }
}
