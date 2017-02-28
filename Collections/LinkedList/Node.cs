using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Node<T>
    {
        public Node<T> Prev { get; set; }
        public Node<T> Next { get; set; }
        public T Value { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }     
    }
}
