using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkedList<T>
    {
        private Node<T> first;
        private Node<T> last;
        private int count;
        
        public int Count { 
            get {
                return count;
            }
        }

        public LinkedList()
        {
            first = null;
            last = null;
            count = 0;
        }

        public void addFirst(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                first.Prev = newNode;
                newNode.Next = first;
                first = newNode;
            }

            count++;
        }

        public void addLast(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (last == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.Next = newNode;
                newNode.Prev = last;
                last = newNode;
            }
            
            count++;
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            Node<T> iter = first;

            while(iter != null)
            {
                yield return iter.Value;
                iter = iter.Next;
            }
        }
    }
}
