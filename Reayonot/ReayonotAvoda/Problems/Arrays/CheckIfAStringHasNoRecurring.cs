using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Problems.Arrays
{
    /**
     * You are given a string and must make sure the string has no two characters that are the same
     * we will solve this by assuming the string is in ascii, this can be done if its in unicode as well though
     * the array size will be larger.
     * 
     * two additional implementations are sorting the array for nlogn and comparing every value at n^2
     */
    class CheckIfAStringHasNoRecurring
    {
        //Create an array of size 256 if its asccii
        public bool hasNoRecurringAssciiArrayMethod(string word)
        {
            if (word.Length > 256)
            {
                return false;
            }

            bool[] characterArray = new bool[256];

            for (int i = 0; i < 256; i++)
            {
                characterArray[i] = false;
            }

            foreach (char c in word)
            {
                if (characterArray[(int)c])
                {
                    return false;
                }

                characterArray[(int) c] = true;
            }

            return true;
        }
    }
}
