using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Searching
    {
        public static int BinarySearch<T>(T[] sortedArr, T val) where T : IComparable
        {
            if (sortedArr == null)
            {
                return -1;
            }

            int lowIndex = 0;
            int highIndex = sortedArr.Length - 1;

            int iterations = 1;

            Console.WriteLine("**********Binary Search**********");

            while (lowIndex <= highIndex)
            {
                Console.WriteLine("BinarySearch iteration number: {0}", iterations);

                int middleIndex = (highIndex + lowIndex) / 2;

                // if the value in middle index is lower than value, search the upper values part 
                if (sortedArr[middleIndex].CompareTo(val) < 0) 
                {
                    lowIndex = middleIndex + 1;
                }
                // else if the value in middle index is greater than value, search the lower values part 
                else if (sortedArr[middleIndex].CompareTo(val) > 0)
                {
                    highIndex = middleIndex - 1;
                }
                else
                {
                    Console.WriteLine("BinarySearch found \"{0}\" at index: {1} \n", val, middleIndex);
                    return middleIndex;
                }

                iterations++;
            }

            Console.WriteLine("BinarySearch - \"{0}\" not found \n", val);
            // Not Found
            return -1;
        }
    }
}
