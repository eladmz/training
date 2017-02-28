using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Stack
{
    class RAStack<T>
    {
        private List<T> stack;
        public RAStack()
        {
            stack = new List<T>();
        }
        public void Push(T element)
        {
            stack.Add(element);
        }
        public T Peek()
        {
            return stack[stack.Count - 1];
        }
        public T Pop()
        {
            T element = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return element;
        }
        public int Count()
        {
            return stack.Count;
        }
        public bool IsEmpty()
        {
            return Count() == 0;
        }
        public void Empty()
        {
            stack.Clear();
        }
    }
}
