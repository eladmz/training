using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Problems.Stacks
{
    /**
     * CheckPoint
     * The question how do you always get the largest element in a stack in O(1) time while keeping
     * Push and pop also at O(1)
     * There is no issue with the amount of space the solution takes up
     * 
     * The solution is to create an additional Stack that contains the largest numbers but only add the numbers
     * that increase in order, this allows us to peek at the max stack to get the largest number for O(1) and
     * retain all other functionality
     */
    class GetLargestElementInStack
    {
        private Stack<int> fullStack;
        private Stack<int> maxStack;

        public GetLargestElementInStack()
        {
            fullStack = new Stack<int>();
            maxStack = new Stack<int>();
        }

        public void PushS(int pushThis)
        {            
            fullStack.Push(pushThis);

            if (maxStack.Count == 0 || maxStack.Peek() <= pushThis)
            {
                maxStack.Push(pushThis);
            }
        }

        public int PopS()
        {
            if (fullStack.Count == 0)
            {
                throw new Exception("The stack is empty");
            }

            int popped = fullStack.Pop();

            if (maxStack.Peek() == popped)
            {
                maxStack.Pop();
            }

            return popped;
        }

        public int GetMaxInStack()
        {
            if (maxStack.Count == 0)
            {
                throw new Exception("The stack is empty");
            }

            return maxStack.Peek();
        }
    }
}
