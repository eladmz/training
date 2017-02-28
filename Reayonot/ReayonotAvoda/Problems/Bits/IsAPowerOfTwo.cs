using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReayonotAvoda.Problems.Bits
{
    /**
     * Brightcom
     * 
     * Given an integer, how do you know if it is a power of 2?
     * 
     * The answer is to reduce it by one and "AND" it with the origional number
     * If it is a power of two the origional number will be a single one and all the other characters will be zeros
     * so the reduced number will be all ones until the placement of the one in the origional number, therefore the "AND"
     * between them should be zero, if its not then the number is not a power of 2.
     * 
     * TODO: another option that i didnt implement is to binary seach for the number since there are only 32 options in an int.
     */
    class IsAPowerOfTwo
    {
        public IsAPowerOfTwo()
        {
            
        }

        //BestSolution
        public bool CheckIsPowerOfTwo(int a)
        {
            if (a <= 0)
            {
                return false;
            }

            return ((byte)a & (byte)(a - 1)) == 0;
        }        
        //Not so amazing
        public bool CheckIsPowerOfTwo2(int a)
        {
            if (a <= 0)
            {
                return false;
            }

            byte aByte = (byte)a;
            int counter = 0;
            char[] arr = aByte.ToString().ToCharArray();

            foreach (char c in arr)
            {
                if (c == 1)
                {
                    counter++;
                    if (counter > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        //Not so amazing
        public bool CheckIsPowerOfTwo3(int a)
        {
            if (a <= 0)
            {
                return false;
            }

            int b = 1;

            while (b <= a)
            {
                if (b == a)
                {
                    return true;
                }
                b *= 2;
            }

            return false;
        }
    }
}
