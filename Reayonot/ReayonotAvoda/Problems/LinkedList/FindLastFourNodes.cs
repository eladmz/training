using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace ReayonotAvoda.Problems.LinkedList
{
    /**
     * Find the last 4 nodes in a linked list where you can only move forward and dont know how many nodes are left.
     */
    class FindLastFourNodes<T>
    {
        public FindLastFourNodes()
        {
            
        }

        public LinkedListNode<T>[] GetLastFourNodes(LinkedListNode<T> providedNode)
        {
            if (providedNode == null)
            {
                return null;
            }
            LinkedListNode<T> firstPointer = providedNode;
            LinkedListNode<T> secondPointer = providedNode;
            LinkedListNode<T>[] returnArray = new LinkedListNode<T>[4];

            for (int i = 0; i < 4; i++)
            {
                if (secondPointer.Next == null)
                {
                    break;
                }
                secondPointer = secondPointer.Next;
            }

            while (secondPointer.Next != null)
            {
                firstPointer = firstPointer.Next;
                secondPointer = secondPointer.Next;
            }

            for (int i = 0; i < 4; i++)
            {
                returnArray[i] = firstPointer;

                if (firstPointer.Next == null)
                {
                    break;
                }
                firstPointer = firstPointer.Next;
            }

            return returnArray;
        }
    }
}
