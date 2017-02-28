using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class MyStack<T>
    {
        private T[] array;
        private int size;
        private int top;

        public MyStack(int size)
        {
            Console.WriteLine("**********Stack Created**********");
            this.size = size;
            top = -1;

            array = new T[size];
        }

        public void Push(T val)
        {
            if (top + 1 < size)
            {
                Console.WriteLine("Push element: {0}", val);
                top++;
                array[top] = val;
            }
            else
            {
                throw new IndexOutOfRangeException("The Stack is Full");
            }
        }

        public T Pop()
        {
            if (top >= 0)
            {
                Console.WriteLine("Pop element: {0}", array[top]);
                top--;
                return array[top + 1];
            }
            else
            {
                throw new IndexOutOfRangeException("The Stack is Empty");
            }
        }

        public T Peek()
        {
            if (top >= 0)
            {
                Console.WriteLine("Peek element: {0}", array[top]);
                return array[top];
            }
            else
            {
                throw new IndexOutOfRangeException("The Stack is Empty");
            }
        }

        public override string ToString()
        {
            return string.Join(", ", array.Where((value, index) => index <= top));
        }
    }
}
