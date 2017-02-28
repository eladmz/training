using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Problems.Arrays
{
    /*
     * XtremeIO
     * The question was to reverse all the elements in an array
     * 
     * The answer is to use a pointer
     */
    class ReversingArrayOrder<T>
    {
        public ReversingArrayOrder()
        {
            
        }

        //with another array - not in place - O(n) time O(n) space
        public T[] ReverseArrayListBasic(T[] origionalArray)
        {
            T[] returnArray = new T[origionalArray.Length];

            int len = origionalArray.Length;

            for (int i = 0; i < len; i++)
            {
                returnArray[i] = origionalArray[len - i];
            }

            return returnArray;
        }

        //With an aditional integer and object - in place - O(n) time O(1) space
        public T[] ReverseArrayListWithoutUsingAnotherArray(T[] origionalArray)
        {
            int pointer = 0;

            while (origionalArray.Length - 1 - pointer > pointer)
            {
                T arrayElement = origionalArray[origionalArray.Length - 1 - pointer];
                origionalArray[origionalArray.Length - 1 - pointer] = origionalArray[pointer];
                origionalArray[pointer] = arrayElement;
                pointer++;
            }

            return origionalArray;
        }
    }
}
