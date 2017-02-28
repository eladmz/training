using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    static class Sorting
    {
        public static T[] BubbleSort<T>(ref T[] arr) where T : System.IComparable<T>
        {
            if (arr == null)
            {
                return arr;
            }

            Console.WriteLine("**********Bubble Sort**********");
            for (int i = arr.Length - 1; i > 1; --i)
            {
                PrintArray(arr);

                for (int j = 0; j < i; ++j)
                {
                    if (arr[j].CompareTo(arr[j+1]) > 0)
                    {
                        SwapValues(ref arr, j, j + 1);
                    }
                }
            }
            return arr;
        }

        // find the mimimum in each iteration and place it on the right index
        public static T[] SelectionSort<T>(ref T[] arr) where T : System.IComparable<T>
        {
            if (arr == null)
            {
                return arr;
            }

            Console.WriteLine("**********Selection Sort**********");
            for (int i = 0; i < arr.Length; ++i)
            {
                PrintArray(arr);

                int minimum = i;

                for (int j = i; j < arr.Length; ++j)
                {
                    if (arr[minimum].CompareTo(arr[j]) > 0)
                    {
                        minimum = j;
                    }
                }

                SwapValues<T>(ref arr, i, minimum);
            }

            return arr;
        }

        // assume [0:x] (x < N) is already sorted and insert the new value to its correct place
        // do that by shift right all the bigger values and place it between the smaller and the bigger parts in the sorted [0:x].
        public static T[] InsertionSort<T>(ref T[] arr) where T : System.IComparable<T>
        {
            if (arr == null)
            {
                return arr;
            }

            Console.WriteLine("**********Insertion Sort**********");
            for (int i = 1; i < arr.Length; ++i)
            {
                PrintArray(arr);

                int j = i;

                T valToInsert = arr[j];

                while((j > 0) && (arr[j - 1].CompareTo(valToInsert) > 0))
                {
                    arr[j] = arr[j - 1];
                    j--;
                }

                arr[j] = valToInsert;
            }

            return arr;
        }

        private static void SwapValues<T>(ref T[] arr, int indexOne, int indexTwo)
        {
            T temp = arr[indexOne];
            arr[indexOne] = arr[indexTwo];
            arr[indexTwo] = temp;
        }

        private static void PrintArray<T>(T[] arr)
        {
            Console.WriteLine(string.Join(",", arr)); 
        }
    }
}
